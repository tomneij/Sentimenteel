using Newtonsoft.Json;
using System;
using System.Linq;
using System.Web.Mvc;
using Website.Helpers;
using Website.Models;

namespace Website.Controllers
{
    public class SentimentController : Controller
    {
        [ChildActionOnly]
        public ActionResult Overview()
        {
            var overviewModel = new OverviewModel();
           
            foreach (var label in Constants.Labels)
            {
                var overviewItem = SentimentHelper.GetSentimentOverview(label);
                overviewModel.Items.Add(overviewItem);
            }

            return View(overviewModel);
        }

        public ActionResult Details(string id)
        {
            var label = LabelHelper.GetLabel(id);
            if (label != null)
            {
                return View(label);
            }

            return View();
        }

        [ChildActionOnly]
        public ActionResult Tweets(string id)
        {
            var label = LabelHelper.GetLabel(id);
            if (label != null)
            {
                var viewModel = new DetailModel
                {
                    Label = label,
                    Tweets = SentimentHelper.GetTweetsByLabel(label).OrderByDescending(tw=> tw.Timestamp).ToList()
                };

                return View(viewModel);
            }

            return View();
        }

        [ChildActionOnly]
        public ActionResult Trend(string id)
        {
            var label = LabelHelper.GetLabel(id);
            if (label != null)
            {
                DateTime from = DateTime.Now.AddDays(-10);

                var model = SentimentHelper.GetDataPointsModel(label, from, DateTime.Now);

                ViewBag.Positive = JsonConvert.SerializeObject(model.PositiveDataPoints);
                ViewBag.Neutral = JsonConvert.SerializeObject(model.NeutralDataPoints);
                ViewBag.Negative = JsonConvert.SerializeObject(model.NegativeDataPoints);

                return View(label);
            }

            return View();
        }
    }
}