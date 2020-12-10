using System;
using System.Configuration;
using Azure;
using Azure.AI.TextAnalytics;
using Website.Models;

namespace Website.Services
{
    public class SentimentService
    {
        private readonly bool mock = true;
        private static readonly AzureKeyCredential credentials = new AzureKeyCredential(ConfigurationManager.AppSettings["CognitiveService.Key"]);
        private static readonly Uri endpoint = new Uri(ConfigurationManager.AppSettings["CognitiveService.Endpoint"]);
        
        #region mock implementation
        private readonly string[] _postiveWords = { "fijn", "goed", "klantvriendelijk" };
        private readonly string[] _negativeWords = { "slecht", "ruk", "verschrikkelijk"};
        #endregion mock implementation

        public Sentiment Analyze(string text, string language = "nl", string country = "nl")
        {
            if (mock)
            {
                #region mock implementation

                int positiveScore = CalculateScore(text, _postiveWords);
                int negativeScore = CalculateScore(text, _negativeWords);
                int sentimentScore = positiveScore - negativeScore;

                if (sentimentScore > 0)
                {
                    return Sentiment.Positive;
                }
                else if (sentimentScore < 0)
                {
                    return Sentiment.Negative;
                }

                return Sentiment.Neutral;

                #endregion mock implementation
            }

            DocumentSentiment documentSentiment = GetDocumentSentiment(text, language, country);

            switch (documentSentiment.Sentiment)
            {
                case TextSentiment.Neutral:
                case TextSentiment.Mixed:
                default:
                    return Sentiment.Neutral;
                case TextSentiment.Positive:
                    return Sentiment.Positive;
                case TextSentiment.Negative:
                    return Sentiment.Negative;
            }
        }

        static DocumentSentiment GetDocumentSentiment(string text, string language, string country)
        {
            var options = new TextAnalyticsClientOptions { DefaultLanguage = language, DefaultCountryHint = country };
            var client = new TextAnalyticsClient(endpoint, credentials, options);
            DocumentSentiment documentSentiment = client.AnalyzeSentiment(text);

            return documentSentiment;
        }

        #region mock implementation

        private int CalculateScore(string text, string[] words)
        {
            int score = 0;

            foreach (string word in words)
            {
                if (text.Contains(word))
                {
                    score++;
                }
            }

            return score;
        }

        #endregion mock implementation
    }
}