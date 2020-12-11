using Newtonsoft.Json;
using System;

namespace Website.Models
{
    public class TweetSentimentModel
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        public string Guid { get; set; }

        public DateTime Timestamp { get; set; }

        public string Message { get; set; }

        public Sentiment Sentiment { get; set; }
    }
}