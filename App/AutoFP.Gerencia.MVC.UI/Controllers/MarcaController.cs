using System.Web.Mvc;
using AutoFP.Gerencia.Application.Interface;
using AutoFP.Gerencia.Application.ValueObjects.Resource;
using AutoFP.Gerencia.MVC.UI.Controllers.Base;
using AutoFP.Gerencia.MVC.UI.Factories;
using AutoFP.Gerencia.MVC.UI.Mapper;
using AutoFP.Gerencia.MVC.UI.ViewModel.Marca;

namespace AutoFP.Gerencia.MVC.UI.Controllers
{
    public class MarcaController : BaseController
    {
        private readonly IMarcaAppService _marcaAppService;
        private readonly ICategoriaPecaAppService _categoriaPecaAppService;

        public MarcaController(IMarcaAppService marcaAppService, ICategoriaPecaAppService categoriaPecaAppService)
        {
            _marcaAppService = marcaAppService;
            _categoriaPecaAppService = categoriaPecaAppService;
        }

        public ActionResult Index(int? page)
        {
            var marcaViewModel = MarcaMappingProfile.ModelToViewModel( _marcaAppService.GetAll(50, 0) );
            return View(marcaViewModel);
        }

        public ActionResult Details(int id)
        {
            var marcaViewModel = MarcaMappingProfile.ModelToViewModelDetail( _marcaAppService.GetByIdForDetail(id) );
            return View(marcaViewModel);
        }

        public ActionResult Create()
        {
            var marcaViewModel = MarcaVmFactory.FillMultiSelectListForCreate( _categoriaPecaAppService.ObterCategoriasPecasParaListaSelecionar() );
            return View(marcaViewModel);
        }

        [HttpPost]
        public ActionResult Create(NewMarcaViewModel marcaViewModel)
        {
            try
            {
                var validationApp = _marcaAppService.Add( MarcaMappingProfile.ViewModelToModelAdd(marcaViewModel) );

                if (!validationApp.IsValid)
                {
                    AddErrors(validationApp);
                    marcaViewModel.CategoriasPecas = MarcaVmFactory.CreateInstanceForMultiSelectList( _categoriaPecaAppService.ObterCategoriasPecasParaListaSelecionar() );
                    return View(marcaViewModel);
                }

                TempData["notification"] = string.Format(MessagesSuccess.MakerRegistred, marcaViewModel.Descricao.ToUpper());
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
                var viewModel = MarcaMappingProfile.ModelToViewModel(_marcaAppService.GetByIdForEdit(id));
                return View(viewModel);
            }
            catch
            {
                TempData["notification"] = MessagesErrors.RemovedUpdatedError;
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult Edit(UpdateMarcaViewModel marcaViewModel)
        {
            try
            {
                var validationApp = _marcaAppService.Update( MarcaMappingProfile.ViewModelToModelUpdate(marcaViewModel) );

                if (!validationApp.IsValid)
                {
                    AddErrors(validationApp);
                    marcaViewModel.CategoriasPecas = MarcaVmFactory.CreateInstanceForMultiSelectList(_categoriaPecaAppService.ObterCategoriasPecasParaListaSelecionar());
                    return View(marcaViewModel);
                }

                TempData["notification"] = string.Format(MessagesSuccess.MakerUpdated, marcaViewModel.Descricao.ToUpper());
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
                var validationApp = _marcaAppService.Remove(id);
                var message = !validationApp.IsValid ? AddErrorsDelete(validationApp) : MessagesSuccess.MakerRemoved;
                return Json(message, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                var message = MessagesErrors.RemovedError;
                return Json(message, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult MarcasByCategoriaPeca(int id)
        {
            try
            {
                var listMarcas = _marcaAppService.GetMarcaByCategoriaPeca(id);
                return Json(listMarcas, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(MessagesErrors.InternalError, JsonRequestBehavior.AllowGet);
            }
        }
    }
}