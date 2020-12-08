using System.Web.Mvc;
using Website.Factories;
using Website.Models;

namespace Website.Controllers
{
    public class OverviewController : Controller
    {

        private string[] Labels = { "ONVZ", "Ohra", "CZ", "VGZ", "ZilverenKruis" };

     
        public ActionResult Index()
        {
            var overviewModel = new OverviewViewModel();
            var overviewFactory = new OverviewFactory();
           
            foreach (var label in Labels)
            {
                var overviewItem = overviewFactory.GetLabelSentiment(label);
                overviewModel.Items.Add(overviewItem);
            }

            return View(overviewModel);
        }
    }
}