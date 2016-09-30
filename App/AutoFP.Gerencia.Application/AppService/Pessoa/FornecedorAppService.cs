using System.Collections.Generic;
using AutoFP.Gerencia.Application.AppService.Base;
using AutoFP.Gerencia.Application.Factories;
using AutoFP.Gerencia.Application.Interface.Pessoa;
using AutoFP.Gerencia.Application.ValueObjects.HelperMapping;
using AutoFP.Gerencia.Application.ValueObjects.TransferObject.Fornecedor;
using AutoFP.Gerencia.Application.ValueObjects.Validation;
using AutoFP.Gerencia.Domain.Interface.Factories;
using AutoFP.Gerencia.Domain.Interface.Factories.Localizacao;
using AutoFP.Gerencia.Domain.Interface.Factories.Pessoa;
using AutoFP.Gerencia.Domain.Interface.Services.Pessoa;
using AutoFP.Gerencia.Infra.Data.Interface;

namespace AutoFP.Gerencia.Application.AppService.Pessoa
{
    public class FornecedorAppService : BaseAppService, IFornecedorAppService
    {
        private readonly IFornecedorService _fornecedorService;
        private readonly IFornecedorFactory _fornecedorFactory;
        private readonly IPessoaJuridicaFactory _pessoaJuridicaFactory;
        private readonly IEnderecoFactory _enderecoFactory;
        private readonly IEmailFactory _emailFactory;
        private readonly ITelefoneFactory _telefoneFactory;

        public FornecedorAppService(IUnitOfWork unitOfWork, IFornecedorService fornecedorService, IFornecedorFactory fornecedorFactory, IPessoaJuridicaFactory pessoaJuridicaFactory, IEnderecoFactory enderecoFactory, IEmailFactory emailFactory, ITelefoneFactory telefoneFactory)
            :base(unitOfWork)
        {
            _fornecedorService = fornecedorService;
            _fornecedorFactory = fornecedorFactory;
            _pessoaJuridicaFactory = pessoaJuridicaFactory;
            _enderecoFactory = enderecoFactory;
            _emailFactory = emailFactory;
            _telefoneFactory = telefoneFactory;
        }

        public IEnumerable<SelectListFornecedorTo> GetAllForSelectList()
        {
            var listFornecedores = _fornecedorService.GetAllForSelectList();
            return FornecedorAppFactory.CreateSelectListInstance(listFornecedores);
        }

        public IEnumerable<ListFornecedorTo> GetAll(int take, int skip)
        {
            var listFornecedores = _fornecedorService.GetAll(take, skip);
            return FornecedorAppFactory.CreateListInstance(listFornecedores);
        }

        public ValidationAppResult Add(CreateFornecedorTo to)
        {
            var fornecedor = _fornecedorFactory.CreateInstance
                (
                    _pessoaJuridicaFactory.CreateInstance(to.Pj.Cnpj, to.Pj.RazaoSocial, to.Pj.NomeFantasia, to.Pj.InscricaoMunicipal, to.Pj.InscricaoEstadual, to.Pj.Isento),
                    _enderecoFactory.CreateInstance(to.Endereco.Logradouro, to.Endereco.Numero, to.Endereco.Bairro, to.Endereco.Cep, to.Endereco.PontoReferencia, false, to.Endereco.Cidade, to.Endereco.Uf, to.Endereco.Complemento),
                    _emailFactory.CreateInstance(to.Email.Email),
                    TelefoneMapping.Mapping(to.Telefones, _telefoneFactory)
                );

            if (!fornecedor.IsValid)
                return DomainToApplicationResult(fornecedor.ValidationResult);

            BeginTransaction();
            _fornecedorService.Add(fornecedor);
            Commit();
            return NewValidation();
        }

        public void Dispose()
        {
            _fornecedorService.Dispose();
        }
    }
}