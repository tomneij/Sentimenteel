using System;

namespace Website.Models
{
    public class TweetModel
    {
        public string Id { get; set; }

        public DateTime Timestamp { get; set; }

        public string Message { get; set; }
    }
}