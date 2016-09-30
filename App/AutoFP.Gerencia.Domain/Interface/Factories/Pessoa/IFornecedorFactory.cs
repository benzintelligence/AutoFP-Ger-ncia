using System.Collections.Generic;
using AutoFP.Gerencia.Domain.Entities;
using AutoFP.Gerencia.Domain.Entities.Localizacao;
using AutoFP.Gerencia.Domain.Entities.Pessoa;

namespace AutoFP.Gerencia.Domain.Interface.Factories.Pessoa
{
    public interface IFornecedorFactory
    {
        Fornecedor CreateInstance(PessoaJuridica pessoaJuridica, Endereco endereco, Email email, IEnumerable<Telefone> telefone);
    }
}