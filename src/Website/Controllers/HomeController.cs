using System.Collections.Generic;
using System.Web.Mvc;
using Newtonsoft.Json;
using Website.Models;

namespace Website.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Trend()
        {
            ViewBag.Message = "Trend";
            var positive = this.SetPositiveDataPoints();
            var neutral = this.SetNeutralDataPoints();
            var negative = this.SetNegativeDataPoints();

            ViewBag.Positive = JsonConvert.SerializeObject(positive);
            ViewBag.Neutral = JsonConvert.SerializeObject(neutral);
            ViewBag.Negative = JsonConvert.SerializeObject(negative);
            return View();
        }

        private List<DataPoint> SetPositiveDataPoints()
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


        private object SetNeutralDataPoints()
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

        private object SetNegativeDataPoints()
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

        public ActionResult About()
        {
            ViewBag.Message = "Over ons";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact";

            return View();
        }
    }
}