using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Website.Models;

namespace Website.Services
{
    public class TwitterFeedService
    {
        public IEnumerable<TweetModel> GetTweets(string keyword, DateTime from, DateTime to)
        {
            // get dynamic tweets


            return Constants.MockedOnvzTweets.OrderByDescending(t=> t.Timestamp);
        }

    }
}