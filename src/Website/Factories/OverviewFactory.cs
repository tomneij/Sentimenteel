using System;
using Website.Helpers;
using Website.Models;

namespace Website.Factories
{
    public class OverviewFactory
    {
        public OverviewFactory ()
        {

        }

        public OverviewItemViewModel GetLabelSentiment(string label)
        {
            var rnd = new Random();

            var allTweets = SentimentHelper.GetTweetsByLabel(label);






            return new OverviewItemViewModel
            {
                Name = label,
                Icon = GetIcon(label),
                Positive = rnd.Next(1,100),
                Neutral = rnd.Next(1,100),
                Negative = rnd.Next(1,100),
            };
        }







        private string GetIcon(string label)
        {
            return $"/Content/Icons/{label}.png";
        }
    }
}