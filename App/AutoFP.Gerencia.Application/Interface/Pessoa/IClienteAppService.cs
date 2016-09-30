using System;
using System.Collections.Generic;
using AutoFP.Gerencia.Application.ValueObjects.TransferObject.Cliente;
using AutoFP.Gerencia.Application.ValueObjects.TransferObject.PessoaFisica;
using AutoFP.Gerencia.Application.ValueObjects.Validation;
using AutoFP.Gerencia.Domain.ValueObjects.DataTransferObject.Cliente;

namespace AutoFP.Gerencia.Application.Interface.Pessoa
{
    public interface IClienteAppService : IDisposable
    {
        ClienteDTO ObterClienteViaCpf(string cpf);

        ClienteDTO ObterClienteViaCnpj(string cnpj);

        IEnumerable<ListClienteTo> GetAll(int take, int skip);

        ValidationAppResult Add(CreateClienteTo to);
    }
}