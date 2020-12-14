using System.Web.Mvc;

namespace Website.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Innovation()
        {
            ViewBag.Message = "De Innovatie";

            return View();
        }


        public ActionResult Future()
        {
            ViewBag.Message = "What's next?";

            return View();
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