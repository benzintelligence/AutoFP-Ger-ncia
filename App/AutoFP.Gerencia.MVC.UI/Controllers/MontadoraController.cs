using System.Web.Mvc;
using AutoFP.Gerencia.Application.Interface;
using AutoFP.Gerencia.Application.ValueObjects.Resource;
using AutoFP.Gerencia.MVC.UI.Controllers.Base;
using AutoFP.Gerencia.MVC.UI.Mapper;
using AutoFP.Gerencia.MVC.UI.ViewModel.Montadora;

namespace AutoFP.Gerencia.MVC.UI.Controllers
{
    public class MontadoraController : BaseController
    {
        private readonly IMontadoraAppService _montadoraAppService;

        public MontadoraController(IMontadoraAppService montadoraAppService)
        {
            _montadoraAppService = montadoraAppService;
        }

        public ActionResult Index()
        {
            var listMontadoraVm = _montadoraAppService.GetAll(50, 0);
            return View( MontadoraMappingProfile.ModelToViewModel(listMontadoraVm) );
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(NewMontadoraViewModel viewModel)
        {
            try
            {
                var validationApp = _montadoraAppService.Add( MontadoraMappingProfile.ViewModelToModelAdd(viewModel) );

                if (!validationApp.IsValid)
                {
                    AddErrors(validationApp);
                    return View(viewModel);
                }

                TempData["notification"] = string.Format(MessagesSuccess.AutomakerRegistred, viewModel.Montadora.ToUpper());
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["notification"] = MessagesErrors.RemovedCreateError;
                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(int id)
        {
            try
            {
                var montadoraTo = _montadoraAppService.GetById(id);
                return View( MontadoraMappingProfile.ModelToViewModel(montadoraTo) );
            }
            catch
            {
                TempData["notification"] = MessagesErrors.RemovedUpdatedError;
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult Edit(UpdateMontadoraViewModel montadoraViewModel)
        {
            try
            {
                var validationApp = _montadoraAppService.Update( MontadoraMappingProfile.ViewModelToModelUpdate(montadoraViewModel) );

                if (!validationApp.IsValid)
                {
                    AddErrors(validationApp);
                    return View(montadoraViewModel);
                }

                TempData["notification"] = string.Format(MessagesSuccess.AutomakerUpdated, montadoraViewModel.Montadora.ToUpper());
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["notification"] = MessagesErrors.RemovedUpdatedError;
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            try
            {
                var validationApp = _montadoraAppService.Remove(id);
                var message = !validationApp.IsValid ? AddErrorsDelete(validationApp) : MessagesSuccess.AutomakerRemoved;
                return Json(message, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(MessagesErrors.RemovedError, JsonRequestBehavior.AllowGet);
            }
        }
    }
}