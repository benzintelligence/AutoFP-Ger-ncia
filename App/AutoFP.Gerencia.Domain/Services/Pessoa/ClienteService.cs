using System.Collections.Generic;
using AutoFP.Gerencia.Domain.Entities.Pessoa;
using AutoFP.Gerencia.Domain.Interface.Repositories.Pessoa;
using AutoFP.Gerencia.Domain.Interface.Services.Pessoa;
using AutoFP.Gerencia.Domain.ValueObjects.DataTransferObject;
using AutoFP.Gerencia.Domain.ValueObjects.DataTransferObject.Cliente;
using AutoFP.Gerencia.Domain.ValueObjects.Validation.ValidationAssertion;

namespace AutoFP.Gerencia.Domain.Services.Pessoa
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public ClienteDTO ObterClienteViaCpf(string cpf)
        {
            var dto = new ClienteDTO();
            return !DocumentAssertionConcern.AssertArgumentCpf(cpf, dto.ValidationResult, "Número de CPF inválido")
                ? dto
                : _clienteRepository.ObterClienteViaCpf(cpf);
        }

        public ClienteDTO ObterClienteViaCnpj(string cnpj)
        {
            var dto = new ClienteDTO();
            return !DocumentAssertionConcern.AssertArgumentCnpj(cnpj, dto.ValidationResult, "Número de CNPJ inválido")
                ? dto
                : _clienteRepository.ObterClienteViaCnpj(cnpj);
        }

        public IEnumerable<ListClientesDTO> GetAll(int take, int skip)
        {
            return _clienteRepository.GetAll(take, skip);
        }

        public void Add(Cliente cliente)
        {
            _clienteRepository.Add(cliente);
        }

        public void Dispose()
        {
            _clienteRepository.Dispose();
        }
    }
}