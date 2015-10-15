using System.Linq;
using System.Web.Mvc;
using Sh4dow.RefuellingHistory.Models;
using Sh4dow.RefuellingHistory.WebApp.Models;

namespace Sh4dow.RefuellingHistory.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly RefuellingHistoryDbContext db = new RefuellingHistoryDbContext();

        [AllowAnonymous]
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                IndexModel model = new IndexModel()
                {
                    CurrentUser = db.Users.Single(u => u.Name == User.Identity.Name)
                };
                return View("Index", model);
            }
            return View("IndexNonAuthorized");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}