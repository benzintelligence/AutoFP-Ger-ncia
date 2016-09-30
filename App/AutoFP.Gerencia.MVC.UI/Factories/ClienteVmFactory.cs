using System.Collections.Generic;
using System.Linq;
using AutoFP.Gerencia.Application.ValueObjects.TransferObject.PessoaFisica;
using AutoFP.Gerencia.MVC.UI.ViewModel.Cliente;

namespace AutoFP.Gerencia.MVC.UI.Factories
{
    internal class ClienteVmFactory
    {
        internal static IEnumerable<ListClienteViewModel> CreateListInstance(IEnumerable<ListClienteTo> obj)
        {
            return obj.Select(to => new ListClienteViewModel
            {
                ClienteId = to.ClienteId,
                TipoPessoa = to.TipoCliente,
                ClienteNome = to.Cliente
            });
        }
    }
}