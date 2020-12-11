using SimpleNetNlp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Events;
using Tweetinvi.Exceptions;
using Tweetinvi.Models;
using Website.Models;
using Website.Repositories;

namespace Website.Services
{
    public class TwitterFeedService
    {
        public async Task GetTweetsRealTime()
        {
            try
            {
                var apiKey = "i4JA1Y6bYPepzfFzy7rdwQlgh";
                var secret = "F4Kdoahs0duK1kwXc66DzSQovlDveEPOOmQT3eiF759alW7kfM";
                var bearerToken = "AAAAAAAAAAAAAAAAAAAAADhBKgEAAAAARo7c8DneV0DIRTuNrQCCKB70AyA%3DTj2trhrBBjNUIR6BuUIK3QUT8YvCajaiQwF7QqEzKvYKkDvSAf";

                // create a consumer only credentials
                var appCredentials = new ConsumerOnlyCredentials(apiKey, secret)
                {
                    BearerToken = bearerToken // bearer token is optional in some cases
                };

                var client = new TwitterClient(appCredentials);
                
                var stream = client.Streams.CreateFilteredStream();

                // add a language
                stream.AddLanguageFilter(LanguageFilter.Dutch);

                // add tracks
                stream.AddTrack("@onvz");

                stream.MatchingTweetReceived += OnMatchedTweet;

                await stream.StartMatchingAnyConditionAsync();
            }
            catch (TwitterException e) 
            {
                if (e.StatusCode == 429) 
                {
                    // Rate limits allowance have been exhausted - do your custom handling
                }
            }
        }

        public IEnumerable<TweetModel> GetMockedTweets(string keyword, DateTime from, DateTime to)
        {
            return Constants.MockedOnvzTweets.OrderByDescending(t=> t.Timestamp);
        }

        private static void OnMatchedTweet(object sender, MatchedTweetReceivedEventArgs args)
        {
            var sanitized = Sanitize(args.Tweet.FullText); //Sanitize Tweet
            var sentence = new Sentence(sanitized); //Get Sentiment

            //Hier moeten we kijken wat eruit komt..
        }

        private static string Sanitize(string raw)
        {
            return Regex.Replace(raw, @"(@[A-Za-z0-9]+)|([^0-9A-Za-z \t])|(\w+:\/\/\S+)", " ").ToString();
        }
    }
}