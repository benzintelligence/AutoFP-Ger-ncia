using System.Collections.Generic;
using AutoFP.Gerencia.Domain.Entities;
using AutoFP.Gerencia.Domain.Entities.Localizacao;
using AutoFP.Gerencia.Domain.Entities.Pessoa;

namespace AutoFP.Gerencia.Domain.Interface.Factories.Pessoa
{
    public interface IClienteFactory
    {
        Cliente CreateInstance(PessoaFisica pf, PessoaJuridica pj, ICollection<Endereco> enderecos, Email email, ICollection<Telefone> telefones);
    }
}