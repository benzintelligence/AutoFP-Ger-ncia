using System.Collections.Generic;
using System.Web.Mvc;
using AutoFP.Gerencia.Application.Interface.Produto;
using AutoFP.Gerencia.MVC.UI.Controllers.Base;
using AutoFP.Gerencia.MVC.UI.Factories;
using AutoFP.Gerencia.MVC.UI.ViewModel.Peca;

namespace AutoFP.Gerencia.MVC.UI.Controllers
{
    public class PecaController : BaseController
    {
        private readonly IPecaAppService _pecaAppService;

        public PecaController(IPecaAppService pecaAppService)
        {
            _pecaAppService = pecaAppService;
        }

        public ActionResult Index()
        {
            return View(new List<ListPecaViewModel>() );
        }

        public ActionResult Create()
        {
            var pecaTo = _pecaAppService.FillScreenElements();
            return View(PecaVmFactory.CreateInstanceForSelectList(pecaTo));
        }

        [HttpPost]
        public ActionResult Create(NewPecaViewModel viewModel)
        {
            return View();
        }
    }
}