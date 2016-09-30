using System.Web.Mvc;
using AutoFP.Gerencia.Application.Interface;
using AutoFP.Gerencia.Application.ValueObjects.Resource;
using AutoFP.Gerencia.MVC.UI.Controllers.Base;
using AutoFP.Gerencia.MVC.UI.Mapper;
using AutoFP.Gerencia.MVC.UI.ViewModel.CategoriaPeca;

namespace AutoFP.Gerencia.MVC.UI.Controllers
{
    public class CategoriaPecaController : BaseController
    {
        private readonly ICategoriaPecaAppService _categoriaPecaAppService;

        public CategoriaPecaController(ICategoriaPecaAppService categoriaPecaAppService)
        {
            _categoriaPecaAppService = categoriaPecaAppService;
        }

        public ActionResult Index(int? page)
        {
            var categoriaPecaViewModel = CategoriaPecaMappingProfile.ModelToViewModel( _categoriaPecaAppService.GetAll(30, 0) );
            return View(categoriaPecaViewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(NewCategoriaPecaViewModel categoriaPecaViewModelviewModel)
        {
            try
            {
                var validationApp = _categoriaPecaAppService.Add( CategoriaPecaMappingProfile.ViewModelToModelAdd(categoriaPecaViewModelviewModel) );

                if (!validationApp.IsValid)
                {
                    AddErrors(validationApp);
                    return View(categoriaPecaViewModelviewModel);
                }

                TempData["notification"] = string.Format(MessagesSuccess.CategoryPieceRegistred, categoriaPecaViewModelviewModel.Descricao.ToUpper());
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
                var viewModel = CategoriaPecaMappingProfile.ModelToViewModel( _categoriaPecaAppService.GetById(id) );
                return View(viewModel);
            }
            catch
            {
                TempData["notification"] = MessagesErrors.RemovedUpdatedError;
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult Edit(UpdateCategoriaPecaViewModel categoriaPecaViewModel)
        {
            try
            {
                var validationApp = _categoriaPecaAppService.Update( CategoriaPecaMappingProfile.ViewModelToModelUpdate(categoriaPecaViewModel) );

                if (!validationApp.IsValid)
                {
                    AddErrors(validationApp);
                    return View(categoriaPecaViewModel);
                }

                TempData["notification"] = string.Format(MessagesSuccess.CategoryPieceUpdated, categoriaPecaViewModel.Descricao.ToUpper());
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
                var validationApp = _categoriaPecaAppService.Remove(id);
                var message = !validationApp.IsValid ? AddErrorsDelete(validationApp) : MessagesSuccess.CategoriaPieceRemoved;
                return Json(message, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(MessagesErrors.RemovedError, JsonRequestBehavior.AllowGet);
            }
        }
    }
}