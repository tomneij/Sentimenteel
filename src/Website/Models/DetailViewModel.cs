using System.Collections.Generic;

namespace Website.Models
{
    public class DetailViewModel
    {
        public LabelModel Label { get; set; }

        public List<TweetSentimentModel> Tweets {get; set;}
    }
}