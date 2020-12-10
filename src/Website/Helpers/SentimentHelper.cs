using System;
using System.Collections.Generic;
using System.Linq;
using Website.Models;
using Website.Services;

namespace Website.Helpers
{
    public static class SentimentHelper
    {
        public static OverviewItemModel GetSentimentOverview(string label)
        {
            var labelModel = LabelHelper.GetLabel(label);
            var allTweets = SentimentHelper.GetTweetsByLabel(label).ToList();
            
            var summorizedTweets = allTweets.GroupBy(tweet => tweet.Sentiment).Select(group => new
            {
                group.Key,
                Count = group.Count()
            }).ToList();

            return new OverviewItemModel
            {
                Name = labelModel.Name,
                Icon = labelModel.Icon,
                Positive = Percentage(allTweets.Count, summorizedTweets.FirstOrDefault(group => group.Key.Equals(Sentiment.Positive))?.Count ?? 0),
                Neutral = Percentage(allTweets.Count,summorizedTweets.FirstOrDefault(group => group.Key.Equals(Sentiment.Neutral))?.Count ?? 0),
                Negative = Percentage(allTweets.Count, summorizedTweets.FirstOrDefault(group => group.Key.Equals(Sentiment.Negative))?.Count ?? 0),
            };
        }

        public static IEnumerable<TweetSentimentModel> GetTweetsByLabel(string label)
        {
            var result = new List<TweetSentimentModel>();
            var twitterFeedService = new TwitterFeedService();
            var sentimentService = new SentimentService();

            //TODO iets met caching of een no-sql databasejes (cosmo db? misschien?)

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

        private static int Percentage(int total, int sub)
        {
            if (total <= 0 || sub <= 0)
            {
                return 0;
            }

            var perc = (sub / (double)total) * 100;
            return (int)Math.Round(perc, 0);
        }

        public static TrendModel GetDataPointsModel(string label, DateTime from, DateTime to)
        {
            var model = new TrendModel
            {
                Label = label
            };

            var tweets = GetTweetsByLabel(label).OrderBy(t => t.Timestamp).ToList();
            
            foreach (var day in EachDay(from, to))
            {
                model.PositiveDataPoints.Add(new DataPoint(day.ToString("dd-MM"), GetTweetCount(tweets, Sentiment.Positive, day)));
                model.NeutralDataPoints.Add(new DataPoint(day.ToString("dd-MM"), GetTweetCount(tweets, Sentiment.Neutral, day)));
                model.NegativeDataPoints.Add(new DataPoint(day.ToString("dd-MM"), GetTweetCount(tweets, Sentiment.Negative, day)));
            }

            return model;
        }

        private static double GetTweetCount(IEnumerable<TweetSentimentModel> tweets, Sentiment sentiment, DateTime date)
        {
            return tweets.Where(t => t.Sentiment.Equals(sentiment)).Count(t => t.Timestamp.Date.Equals(date.Date));
        }

        private static IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
            {
                yield return day;
            }
        }
    }
}