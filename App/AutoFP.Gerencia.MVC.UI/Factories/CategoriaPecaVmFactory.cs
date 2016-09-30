using System.Collections.Generic;
using System.Linq;
using AutoFP.Gerencia.Application.ValueObjects.TransferObject.CategoriaPeca;
using AutoFP.Gerencia.MVC.UI.ViewModel.CategoriaPeca;

namespace AutoFP.Gerencia.MVC.UI.Factories
{
    internal static class CategoriaPecaVmFactory
    {
        internal static UpdateCategoriaPecaViewModel CreateInstance(UpdateCategoriaPecaTo obj)
        {
            return new UpdateCategoriaPecaViewModel { CategoriaPecaId = obj.CategoriaPecaId, Descricao = obj.Descricao };
        }

        internal static IEnumerable<ListCategoriaPecaViewModel> CreateInstance(IEnumerable<ListCategoriaPecaTo> obj)
        {
            return obj.Select(to => new ListCategoriaPecaViewModel
            {
                CategoriaPecaId = to.CategoriaPecaId, Descricao = to.Descricao
            });
        }
    }
}