using System.Linq;
using System.Web.Mvc;
using Website.Factories;
using Website.Helpers;
using Website.Models;

namespace Website.Controllers
{
    public class SentimentController : Controller
    {

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
                var viewModel = new DetailViewModel
                {
                    Label = label,
                    Tweets = SentimentHelper.GetTweetsByLabel(label.Name)
                };

                return View(viewModel);
            }

            return View();
        }

        public ActionResult Trend()
        {
            return View();
        }


        private LabelModel GetLabel(string id)
        {
            return Constants.Labels.FirstOrDefault(l => l.Name.Equals(id));
        }
    }
}