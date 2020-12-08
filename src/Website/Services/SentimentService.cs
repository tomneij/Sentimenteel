namespace Website.Services
{
    public class SentimentService
    {
        private readonly string[] _postiveWords = { "fijn", "goed", "klantvriendelijk" };
        private readonly string[] _negativeWords = { "slecht", "ruk", "verschrikkelijk"};

        public Sentiment Analyze(string text)
        {
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
        }

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
    }
}