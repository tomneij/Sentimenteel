using System;
using System.Collections.Generic;
using Website.Models;
using Website.Services;

namespace Website.Helpers
{
    public static class SentimentHelper
    {

        public static OverviewItemModel GetSentimentOverview(string label)
        {
            var rnd = new Random();            

            var labelModel = LabelHelper.GetLabel(label);
            var allTweets = SentimentHelper.GetTweetsByLabel(label);

            return new OverviewItemModel
            {
                Name = labelModel.Name,
                Icon = labelModel.Icon,
                Positive = rnd.Next(1, 100),
                Neutral = rnd.Next(1, 100),
                Negative = rnd.Next(1, 100),
            };
        }


        public static List<TweetSentimentModel> GetTweetsByLabel(string label)
        {
            var result = new List<TweetSentimentModel>();
            var twitterFeedService = new TwitterFeedService();
            var sentimentService = new SentimentService();

            var tweets = twitterFeedService.GetTweets(label, DateTime.Now.AddDays(-10), DateTime.Now);
            foreach (var tweet in tweets)
            {
                var tweetSentiment = new TweetSentimentModel
                {
                    Timestamp = tweet.Timestamp,
                    Message = tweet.Message,
                    Sentiment = sentimentService.Analyze(tweet.Message)
                };


                result.Add(tweetSentiment);
            }

            return result;
        }

    }
}