using System.Collections.Generic;

namespace Website.Models
{
    public class DetailModel
    {
        public LabelModel Label { get; set; }

        public List<TweetSentimentModel> Tweets {get; set;}
    }
}