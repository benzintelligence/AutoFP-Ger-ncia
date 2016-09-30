using System.Collections.Generic;
using System.Linq;
using AutoFP.Gerencia.Domain.Entities;
using AutoFP.Gerencia.Domain.Entities.Localizacao;
using AutoFP.Gerencia.Domain.Entities.Pessoa;
using AutoFP.Gerencia.Domain.Interface.Factories.Pessoa;
using AutoFP.Gerencia.Domain.ValueObjects.Enums;

namespace AutoFP.Gerencia.Domain.Factories.Pessoa
{
    public class FornecedorFactory : IFornecedorFactory
    {
        public Fornecedor CreateInstance(PessoaJuridica pessoaJuridica, Endereco endereco, Email email, IEnumerable<Telefone> telefones)
        {
            var fornecedor = new Fornecedor();

            if (!pessoaJuridica.IsValid)
                fornecedor.ValidationResult.AddError(pessoaJuridica.ValidationResult);

            if (!endereco.IsValid)
                fornecedor.ValidationResult.AddError(endereco.ValidationResult);

            if (!email.IsValid)
                fornecedor.ValidationResult.AddError(email.ValidationResult);

            foreach (var tel in telefones.Where(tel => !tel.IsValid))
                fornecedor.ValidationResult.AddError(tel.ValidationResult);

            if (!fornecedor.IsValid)
                return fornecedor;

            fornecedor.Pessoa = new Entities.Pessoa.Pessoa((int) TipoPessoa.PersonJuridical)
            {
                PessoaJuridica = pessoaJuridica,
                Enderecos = new List<Endereco> {endereco},
                Email = email,
                Telefones = telefones.ToList()
            };

            fornecedor.Pessoa.Fornecedor = fornecedor;
            return fornecedor;
        }
    }
}