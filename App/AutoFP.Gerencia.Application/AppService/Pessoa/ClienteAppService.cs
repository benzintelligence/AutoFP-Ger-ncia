using System.Collections.Generic;
using AutoFP.Gerencia.Application.AppService.Base;
using AutoFP.Gerencia.Application.Factories;
using AutoFP.Gerencia.Application.Interface.Pessoa;
using AutoFP.Gerencia.Application.ValueObjects.HelperMapping;
using AutoFP.Gerencia.Application.ValueObjects.TransferObject.Cliente;
using AutoFP.Gerencia.Application.ValueObjects.TransferObject.PessoaFisica;
using AutoFP.Gerencia.Application.ValueObjects.Validation;
using AutoFP.Gerencia.Domain.Interface.Factories;
using AutoFP.Gerencia.Domain.Interface.Factories.Localizacao;
using AutoFP.Gerencia.Domain.Interface.Factories.Pessoa;
using AutoFP.Gerencia.Domain.Interface.Services.Pessoa;
using AutoFP.Gerencia.Domain.ValueObjects.DataTransferObject.Cliente;
using AutoFP.Gerencia.Infra.Data.Interface;

namespace AutoFP.Gerencia.Application.AppService.Pessoa
{
    public class ClienteAppService : BaseAppService, IClienteAppService
    {
        private readonly IClienteService _clienteService;
        private readonly IClienteFactory _clienteFactory;
        private readonly IPessoaFisicaFactory _pessoaFisicaFactory;
        private readonly IPessoaJuridicaFactory _pessoaJuridicaFactory;
        private readonly IEnderecoFactory _enderecoFactory;
        private readonly IEmailFactory _emailFactory;
        private readonly ITelefoneFactory _telefoneFactory;

        public ClienteAppService(IUnitOfWork unitOfWork, IClienteService clienteService, IClienteFactory clienteFactory, IPessoaFisicaFactory pessoaFisicaFactory, IPessoaJuridicaFactory pessoaJuridicaFactory, IEmailFactory emailFactory, ITelefoneFactory telefoneFactory, IEnderecoFactory enderecoFactory)
            : base(unitOfWork)
        {
            _clienteService = clienteService;
            _clienteFactory = clienteFactory;
            _pessoaFisicaFactory = pessoaFisicaFactory;
            _pessoaJuridicaFactory = pessoaJuridicaFactory;
            _emailFactory = emailFactory;
            _telefoneFactory = telefoneFactory;
            _enderecoFactory = enderecoFactory;
        }

        public ClienteDTO ObterClienteViaCpf(string cpf)
        {
            return _clienteService.ObterClienteViaCpf(cpf);
        }

        public ClienteDTO ObterClienteViaCnpj(string cnpj)
        {
            return _clienteService.ObterClienteViaCnpj(cnpj);
        }

        public IEnumerable<ListClienteTo> GetAll(int take, int skip)
        {
            var listClientes = _clienteService.GetAll(take, skip);
            return ClienteAppFactory.CreateListInstance(listClientes);
        }

        public ValidationAppResult Add(CreateClienteTo to)
        {
            var cliente = _clienteFactory.CreateInstance
                (
                    to.Pf == null ? null : _pessoaFisicaFactory.CreateInstance(to.Pf.Cpf, to.Pf.Nome, to.Pf.Sobrenome),
                    to.Pj == null ? null : _pessoaJuridicaFactory.CreateInstance(to.Pj.Cnpj, to.Pj.RazaoSocial, to.Pj.NomeFantasia, to.Pj.InscricaoMunicipal, to.Pj.InscricaoEstadual, to.Pj.Isento),
                    EnderecoMapping.Mapping(to.Enderecos, _enderecoFactory),
                    _emailFactory.CreateInstance(to.Email.Email),
                    TelefoneMapping.Mapping(to.Telefones, _telefoneFactory)
                );

            if (!cliente.IsValid)
                return DomainToApplicationResult(cliente.ValidationResult);

            BeginTransaction();
            _clienteService.Add(cliente);
            Commit();
            return NewValidation();
        }

        public void Dispose()
        {
            _clienteService.Dispose();
        }
    }
}