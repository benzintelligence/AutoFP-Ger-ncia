using System.Collections.Generic;
using System.Linq;
using AutoFP.Gerencia.Application.ValueObjects.TransferObject.Endereco;
using AutoFP.Gerencia.Domain.Entities.Localizacao;
using AutoFP.Gerencia.Domain.Interface.Factories.Localizacao;

namespace AutoFP.Gerencia.Application.ValueObjects.HelperMapping
{
    internal class EnderecoMapping
    {
        internal static ICollection<Endereco> Mapping(IEnumerable<CreateEnderecoTo> to, IEnderecoFactory factory)
        {
            return to
                .Select(e => factory.CreateInstance(e.Logradouro, e.Numero, e.Bairro, e.Cep, e.PontoReferencia, e.EnderecoCobranca, e.Cidade, e.Uf, e.Complemento))
                .ToList();
        }
    }
}