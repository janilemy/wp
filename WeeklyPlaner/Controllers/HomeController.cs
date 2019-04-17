using System.Web.Mvc;

namespace WeeklyPlaner.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}