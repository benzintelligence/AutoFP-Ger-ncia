using System.Collections.Generic;
using AutoFP.Gerencia.Application.Factories;
using AutoFP.Gerencia.Application.ValueObjects.TransferObject.Cliente;
using AutoFP.Gerencia.Application.ValueObjects.TransferObject.Endereco;
using AutoFP.Gerencia.Application.ValueObjects.TransferObject.PessoaFisica;
using AutoFP.Gerencia.Application.ValueObjects.TransferObject.Telefone;
using AutoFP.Gerencia.MVC.UI.Factories;
using AutoFP.Gerencia.MVC.UI.ViewModel.Cliente;

namespace AutoFP.Gerencia.MVC.UI.Mapper
{
    internal class ClienteMappingProfile
    {
        internal static CreateClienteTo ViewModelToModelAdd(NewClienteViewModel obj)
        {
            var clienteTo = ClienteAppFactory.CreateInstance();

            if (obj.IsPessoaFisica)
            {
                clienteTo.Pf = PessoaFisicaAppFactory.CreateInstance(obj.Cpf, obj.Nome, obj.Sobrenome);
                clienteTo.Pj = null;
            }
            else
            {
                clienteTo.Pf = null;
                clienteTo.Pj = PessoaJuridicaAppFactory.CreateInstance(obj.Cnpj, obj.RazaoSocial, obj.NomeFantasia, obj.InscricaoMunicipal, obj.InscricaoEstadual, obj.Isento);
            }

            clienteTo.IsPessoaFisica = obj.IsPessoaFisica;
            clienteTo.Enderecos = new List<CreateEnderecoTo>
            {
                EnderecoAppFactory.CreateInstance(obj.Logradouro, obj.Numero, obj.Bairro, obj.Cep, obj.PontoReferencia, obj.Cidade, obj.Estado, obj.Complemento, true)
            };

            if (obj.IsEntrega)
            {
                var enderecoEntrega = clienteTo.Enderecos[0].Copy();
                enderecoEntrega.EnderecoCobranca = false;
                clienteTo.Enderecos.Add(enderecoEntrega);
            }
            else
            {
                var endTo = EnderecoAppFactory.CreateInstance(obj.Logradouro2, obj.Numero2, obj.Bairro2, obj.Cep2, obj.PontoReferencia2, obj.Cidade2, obj.Estado2, obj.Complemento2, false);
                clienteTo.Enderecos.Add(endTo);
            }

            clienteTo.Email = EmailAppFactory.CreateInstance(obj.Email);
            clienteTo.Telefones = new List<CreateTelefoneTo>
            {
                TelefoneAppFactory.CreateInstance(obj.TipoTelefone1, obj.TelefoneNumero1),
                TelefoneAppFactory.CreateInstance(obj.TipoTelefone2, obj.TelefoneNumero2)
            };

            return clienteTo;
        }

        internal static IEnumerable<ListClienteViewModel> ModelToViewModel(IEnumerable<ListClienteTo> obj)
        {
            return ClienteVmFactory.CreateListInstance(obj);
        }
    }
}