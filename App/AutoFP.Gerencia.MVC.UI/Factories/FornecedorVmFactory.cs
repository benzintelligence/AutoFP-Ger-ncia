using System.Collections.Generic;
using System.Linq;
using AutoFP.Gerencia.Application.ValueObjects.TransferObject.Fornecedor;
using AutoFP.Gerencia.MVC.UI.ViewModel.Fornecedor;

namespace AutoFP.Gerencia.MVC.UI.Factories
{
    internal static class FornecedorVmFactory
    {
        internal static IEnumerable<ListFornecedorViewModel> CreateListInstance(IEnumerable<ListFornecedorTo> obj)
        {
            return obj.Select(to => new ListFornecedorViewModel
            {
                FornecedorId = to.FornecedorId,
                Cnpj = to.Cnpj,
                RazaoSocial = to.RazaoSocial
            });
        }
    }
}