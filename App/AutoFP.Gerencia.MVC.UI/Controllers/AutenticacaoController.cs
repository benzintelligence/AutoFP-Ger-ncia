using System;
using System.Web.Mvc;
using System.Web.Security;
using AutoFP.Gerencia.Infra.CrossCutting.Security.Interface.Service;
using AutoFP.Gerencia.MVC.UI.Controllers.Base;
using AutoFP.Gerencia.MVC.UI.ViewModel;

namespace AutoFP.Gerencia.MVC.UI.Controllers
{
    [AllowAnonymous]
    public class AutenticacaoController : BaseController
    {
        private readonly IUsuarioService _usuarioService;

        public AutenticacaoController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var usuario = _usuarioService.Authenticate(vm.Usuario, vm.Senha);

                    if (!usuario.IsValid)
                    {
                        AddErrors(usuario.ValidationResult);
                        return View();
                    }

                    FormsAuthentication.SetAuthCookie(vm.Usuario, false);
                    return RedirectToAction("Index", "Dashboard");
                }

                ModelState.AddModelError("", @"É necessário informar suas credenciais");
                return View();
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", @"Erro interno, tente novamente em instantes.");
                return View();
            }
        }

        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return View("Login");
        }
    }
}