using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoFP.Gerencia.Application.Interface.Pessoa;
using AutoFP.Gerencia.Application.ValueObjects.Resource;
using AutoFP.Gerencia.MVC.UI.Controllers.Base;
using AutoFP.Gerencia.MVC.UI.Mapper;
using AutoFP.Gerencia.MVC.UI.ViewModel.Cliente;

namespace AutoFP.Gerencia.MVC.UI.Controllers
{
    public class ClienteController : BaseController
    {
        private readonly IClienteAppService _clienteAppService;

        public ClienteController(IClienteAppService clienteAppService)
        {
            _clienteAppService = clienteAppService;
        }

        public ActionResult Index()
        {
            // var listClientsVm = ClienteMappingProfile.ModelToViewModel(_clienteAppService.GetAll(30, 0));
            var listClientsVm = new List<ListClienteViewModel>
            {
                new ListClienteViewModel { ClienteId = 1, ClienteNome = "Cliente fictício", TipoPessoa = "Pessoa física" }
            };

            return View(listClientsVm);
        }

        public JsonResult ObterClienteViaCpf(string cpf)
        {
            try
            {
                if (string.IsNullOrEmpty(cpf))
                    return JsonResponse(null, new List<string> { "Nome de parâmetro inválido" }, 400);

                var clienteDto = _clienteAppService.ObterClienteViaCpf(cpf);

                if (!clienteDto.IsValid)
                    return JsonResponse(null, clienteDto.ValidationResult.Errors, 400);

                return JsonResponse(clienteDto, null, 201);
            }
            catch (Exception e)
            {
                return JsonResponse(null, new List<string> { "Erro interno, tente novamente em instantes" }, 500);
            }
        }

        public JsonResult ObterClienteViaCnpj(string cnpj)
        {
            try
            {
                if (string.IsNullOrEmpty(cnpj))
                    return JsonResponse(null, new List<string> { "Nome de parâmetro inválido" }, 400);

                var clienteDto = _clienteAppService.ObterClienteViaCnpj(cnpj);

                if (!clienteDto.IsValid)
                    return JsonResponse(null, clienteDto.ValidationResult.Errors, 400);

                return JsonResponse(clienteDto, null, 200);
            }
            catch (Exception e)
            {
                return JsonResponse(null, new List<string> { "Erro interno, tente novamente em instantes" }, 500);
            }
        }

        public ActionResult Create()
        {
            var novoCliente = new NewClienteViewModel { IsPessoaFisica = true, IsEntrega = true };
            return View(novoCliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NewClienteViewModel clienteViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", MessagesErrors.PleaseCorrectTheErrorsBelow);
                    return View(clienteViewModel);
                }

                var validation = _clienteAppService.Add(ClienteMappingProfile.ViewModelToModelAdd(clienteViewModel));

                if (!validation.IsValid)
                {
                    AddErrors(validation);
                    return View(clienteViewModel);
                }

                TempData["notification"] = string.Format(MessagesSuccess.ClientRegistred, (clienteViewModel.RazaoSocial ?? clienteViewModel.Nome).ToUpper());
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["notification"] = MessagesErrors.RemovedCreateError;
                return RedirectToAction("Index");
            }
        }
    }
}