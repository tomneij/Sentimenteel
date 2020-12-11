using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Website.Models;
using Website.Repositories;
using Website.Services;

namespace Website.Helpers
{
    public static class SentimentHelper
    {
        public static OverviewItemModel GetSentimentOverview(LabelModel label)
        {
            var allTweets = SentimentHelper.GetTweetsByLabel(label).ToList();
            
            var summorizedTweets = allTweets.GroupBy(tweet => tweet.Sentiment).Select(group => new
            {
                group.Key,
                Count = group.Count()
            }).ToList();

            return new OverviewItemModel
            {
                Name = label.Name,
                Icon = label.Icon,
                Positive = Percentage(allTweets.Count, summorizedTweets.FirstOrDefault(group => group.Key.Equals(Sentiment.Positive))?.Count ?? 0),
                Neutral = Percentage(allTweets.Count,summorizedTweets.FirstOrDefault(group => group.Key.Equals(Sentiment.Neutral))?.Count ?? 0),
                Negative = Percentage(allTweets.Count, summorizedTweets.FirstOrDefault(group => group.Key.Equals(Sentiment.Negative))?.Count ?? 0),
            };
        }

        public static IEnumerable<TweetSentimentModel> GetTweetsByLabel(LabelModel label)
        {
            var twitterFeedService = new TwitterFeedService();
            var sentimentService = new SentimentService();
            var tweetRepository = new TweetRepository();

            var storedTweets = Task.Run(async () => await tweetRepository.RetrieveAllTweets()).Result
                .Where(tw=>tw.Label.Equals(label.Name));
            result.AddRange(storedTweets);

            var tweets =  Task.Run(async () => await twitterFeedService.GetTweetsRealTime(label.Keyword)).Result;
            foreach (var tweet in tweets)
            {
                if (!storedTweets.Any(st => st.Id.Equals(tweet.Id)))
                {
                    var tweetSentiment = new TweetSentimentModel
                    {
                        Id = tweet.Id,
                        Label = label.Name,
                        Timestamp = tweet.Timestamp,
                        Message = tweet.Message,
                        Sentiment = sentimentService.Analyze(tweet.Message)
                    };

                    Task.Run(async () => await tweetRepository.AddTweetIfNotExists(tweetSentiment)).Wait();
                    result.Add(tweetSentiment);
                }
            }

            return tweets;
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

        public static TrendModel GetDataPointsModel(LabelModel label, DateTime from, DateTime to)
        {
            var model = new TrendModel
            {
                Label = label.Name
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