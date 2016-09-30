using System.Collections.Generic;
using System.Web.Mvc;
using AutoFP.Gerencia.MVC.UI.Controllers.Base;
using AutoFP.Gerencia.MVC.UI.ViewModel.Pedido;

namespace AutoFP.Gerencia.MVC.UI.Controllers
{
    public class PedidoController : BaseController
    {
        public ActionResult Index()
        {
            return View(new List<ListPedidoViewModel>());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string teste)
        {
            return View();
        }
    }
}