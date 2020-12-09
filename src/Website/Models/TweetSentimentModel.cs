using System;

namespace Website.Models
{
    public class TweetSentimentModel
    {
        public DateTime Timestamp  { get; set; }

        public string Message { get; set; }

        public Sentiment Sentiment { get; set; }
    }
}