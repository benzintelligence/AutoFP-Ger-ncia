using System;
using System.Collections.Generic;
using AutoFP.Gerencia.Domain.Entities.Pessoa;
using AutoFP.Gerencia.Domain.ValueObjects.DataTransferObject;
using AutoFP.Gerencia.Domain.ValueObjects.DataTransferObject.Cliente;

namespace AutoFP.Gerencia.Domain.Interface.Repositories.Pessoa
{
    public interface IClienteRepository : IDisposable
    {
        ClienteDTO ObterClienteViaCpf(string cpf);

        ClienteDTO ObterClienteViaCnpj(string cnpj);

        IEnumerable<ListClientesDTO> GetAll(int take, int skip);

        void Add(Cliente cliente);
    }
}