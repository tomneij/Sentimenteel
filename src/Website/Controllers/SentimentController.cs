﻿using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Website.Factories;
using Website.Helpers;
using Website.Models;

namespace Website.Controllers
{
    public class SentimentController : Controller
    {
        [ChildActionOnly]
        public ActionResult Overview()
        {
            var overviewModel = new OverviewViewModel();
            var overviewFactory = new OverviewFactory();
           
            foreach (var label in Constants.Labels)
            {
                var overviewItem = overviewFactory.GetLabelSentiment(label.Name);
                overviewModel.Items.Add(overviewItem);
            }

            return View(overviewModel);
        }

        public ActionResult Details(string id)
        {
            var label = GetLabel(id);
            if (label != null)
            {
                return View(label);
            }

            return View();
        }

        [ChildActionOnly]
        public ActionResult Tweets(string id)
        {
            var label = GetLabel(id);
            if (label != null)
            {
                var viewModel = new DetailViewModel
                {
                    Label = label,
                    Tweets = SentimentHelper.GetTweetsByLabel(label.Name)
                };

                return View(viewModel);
            }

            return View();
        }

        [ChildActionOnly]
        public ActionResult Trend(string id)
        {
            var label = GetLabel(id);
            if (label != null)
            {
                var positive = SetPositiveDataPoints();
                var neutral = SetNeutralDataPoints();
                var negative = SetNegativeDataPoints();

                ViewBag.Positive = JsonConvert.SerializeObject(positive);
                ViewBag.Neutral = JsonConvert.SerializeObject(neutral);
                ViewBag.Negative = JsonConvert.SerializeObject(negative);

                return View(label);
            }

            return View();
        }

        private static LabelModel GetLabel(string id)
        {
            return Constants.Labels.FirstOrDefault(l => l.Name.Equals(id));
        }

        private static List<DataPoint> SetPositiveDataPoints()
        {
            var dataPoints = new List<DataPoint>
            {
                new DataPoint("Jan", 72),
                new DataPoint("Feb", 67),
                new DataPoint("Mar", 55),
                new DataPoint("Apr", 42),
                new DataPoint("May", 40),
                new DataPoint("Jun", 35)
            };

            return dataPoints;
        }

        private static List<DataPoint> SetNeutralDataPoints()
        {
            var dataPoints = new List<DataPoint>
            {
                new DataPoint("Jan", 48),
                new DataPoint("Feb", 56),
                new DataPoint("Mar", 50),
                new DataPoint("Apr", 47),
                new DataPoint("May", 65),
                new DataPoint("Jun", 69)
            };

            return dataPoints;
        }

        private static List<DataPoint> SetNegativeDataPoints()
        {
            var dataPoints = new List<DataPoint>
            {
                new DataPoint("Jan", 38),
                new DataPoint("Feb", 46),
                new DataPoint("Mar", 55),
                new DataPoint("Apr", 70),
                new DataPoint("May", 77),
                new DataPoint("Jun", 91)
            };

            return dataPoints;
        }
    }
}