using System.Web.Mvc;
using AutoFP.Gerencia.Application.Interface.Pessoa;
using AutoFP.Gerencia.Application.ValueObjects.Resource;
using AutoFP.Gerencia.MVC.UI.Controllers.Base;
using AutoFP.Gerencia.MVC.UI.Mapper;
using AutoFP.Gerencia.MVC.UI.ViewModel.Fornecedor;

namespace AutoFP.Gerencia.MVC.UI.Controllers
{
    public class FornecedorController : BaseController
    {
        private readonly IFornecedorAppService _fornecedorAppService;

        public FornecedorController(IFornecedorAppService fornecedorAppService)
        {
            _fornecedorAppService = fornecedorAppService;
        }

        public ActionResult Index()
        {
            var listFornecedoresVm = FornecedorMappingProfile.ModelToViewModel( _fornecedorAppService.GetAll(30, 0) );
            return View(listFornecedoresVm);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(NewFornecedorViewModel fornecedorVm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", MessagesErrors.PleaseCorrectTheErrorsBelow);
                    return View(fornecedorVm);
                }

                var validationApp = _fornecedorAppService.Add(FornecedorMappingProfile.ViewModelToModelAdd(fornecedorVm));

                if (!validationApp.IsValid)
                {
                    AddErrors(validationApp);
                    return View(fornecedorVm);
                }

                TempData["notification"] = string.Format(MessagesSuccess.ProviderRegistred, fornecedorVm.RazaoSocial.ToUpper());
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["notification"] = MessagesErrors.RemovedCreateError;
                return RedirectToAction("Index");
            }
        }
    }
}