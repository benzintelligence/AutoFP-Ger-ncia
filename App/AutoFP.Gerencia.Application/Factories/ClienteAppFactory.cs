using System.Collections.Generic;
using System.Linq;
using AutoFP.Gerencia.Application.ValueObjects.TransferObject.Cliente;
using AutoFP.Gerencia.Application.ValueObjects.TransferObject.PessoaFisica;
using AutoFP.Gerencia.Domain.ValueObjects.DataTransferObject;

namespace AutoFP.Gerencia.Application.Factories
{
    public static class ClienteAppFactory
    {
        public static CreateClienteTo CreateInstance()
        {
            return new CreateClienteTo();
        }

        public static IEnumerable<ListClienteTo> CreateListInstance(IEnumerable<ListClientesDTO> clientes)
        {
            return clientes.Select(c => new ListClienteTo
            {
                ClienteId = c.ClienteId, Cliente = c.Cliente, TipoCliente = c.TipoPessoa
            });
        }
    }
}