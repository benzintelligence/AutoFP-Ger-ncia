using System.Collections.Generic;
using AutoFP.Gerencia.Application.Factories;
using AutoFP.Gerencia.Application.ValueObjects.TransferObject.Fornecedor;
using AutoFP.Gerencia.Application.ValueObjects.TransferObject.Telefone;
using AutoFP.Gerencia.MVC.UI.Factories;
using AutoFP.Gerencia.MVC.UI.ViewModel.Fornecedor;

namespace AutoFP.Gerencia.MVC.UI.Mapper
{
    internal static class FornecedorMappingProfile
    {
        internal static CreateFornecedorTo ViewModelToModelAdd(NewFornecedorViewModel obj)
        {
            var fornecedor = FornecedorAppFactory.CreateInstance();

            fornecedor.Pj = PessoaJuridicaAppFactory.CreateInstance(obj.Cnpj, obj.RazaoSocial, obj.NomeFantasia, obj.InscricaoMunicipal, obj.InscricaoEstadual, obj.Isento);
            fornecedor.Endereco = EnderecoAppFactory.CreateInstance(obj.Rua, obj.EnderecoNumero, obj.Bairro, obj.Cep, obj.PontoReferencia, obj.Cidade, obj.Estado, obj.Complemento);
            fornecedor.Email = EmailAppFactory.CreateInstance(obj.Email);
            fornecedor.Telefones = new List<CreateTelefoneTo>
            {
                TelefoneAppFactory.CreateInstance(obj.TipoTelefone1, obj.TelefoneNumero1),
                TelefoneAppFactory.CreateInstance(obj.TipoTelefone2, obj.TelefoneNumero2)
            };

            return fornecedor;
        }

        internal static IEnumerable<ListFornecedorViewModel> ModelToViewModel(IEnumerable<ListFornecedorTo> obj)
        {
            return FornecedorVmFactory.CreateListInstance(obj);
        }
    }
}