using System.Web.Mvc;
using AutoFP.Gerencia.MVC.UI.Controllers.Base;

namespace AutoFP.Gerencia.MVC.UI.Controllers
{
    public class DashboardController : BaseController
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            return View();
        }
    }
}