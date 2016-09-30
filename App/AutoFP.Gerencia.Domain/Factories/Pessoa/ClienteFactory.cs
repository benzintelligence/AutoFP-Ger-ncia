using System.Collections.Generic;
using AutoFP.Gerencia.Domain.Entities;
using AutoFP.Gerencia.Domain.Entities.Localizacao;
using AutoFP.Gerencia.Domain.Entities.Pessoa;
using AutoFP.Gerencia.Domain.Interface.Factories.Pessoa;
using AutoFP.Gerencia.Domain.ValueObjects.Enums;

namespace AutoFP.Gerencia.Domain.Factories.Pessoa
{
    public class ClienteFactory : IClienteFactory
    {
        public Cliente CreateInstance(PessoaFisica pf, PessoaJuridica pj, ICollection<Endereco> enderecos, Email email, ICollection<Telefone> telefones)
        {
            var cliente = new Cliente();

            if (pf != null && !pf.IsValid)
                cliente.ValidationResult.AddError(pf.ValidationResult);

            if (pj != null && !pj.IsValid)
                cliente.ValidationResult.AddError(pj.ValidationResult);

            if (!email.IsValid)
                cliente.ValidationResult.AddError(email.ValidationResult);

            foreach (var end in enderecos)
            {
                if (!end.IsValid)
                    cliente.ValidationResult.AddError(end.ValidationResult);
            }

            foreach (var tel in telefones)
            {
                if (!tel.IsValid)
                    cliente.ValidationResult.AddError(tel.ValidationResult);
            }

            cliente.Pessoa = new Entities.Pessoa.Pessoa(tipoPessoa: pf != null ? (int) TipoPessoa.PersonPhysical : (int) TipoPessoa.PersonJuridical)
            {
                PessoaFisica = pf,
                PessoaJuridica = pj,
                Enderecos = enderecos,
                Email = email,
                Telefones = telefones
            };

            return cliente;
        }
    }
}