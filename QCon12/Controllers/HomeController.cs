#region

using System.Web.Mvc;

#endregion

namespace QCon12.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}