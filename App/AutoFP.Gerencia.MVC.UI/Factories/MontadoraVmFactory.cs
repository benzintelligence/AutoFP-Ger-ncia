using System.Collections.Generic;
using System.Linq;
using AutoFP.Gerencia.Application.ValueObjects.TransferObject.Montadora;
using AutoFP.Gerencia.MVC.UI.ViewModel.Montadora;

namespace AutoFP.Gerencia.MVC.UI.Factories
{
    internal static class MontadoraVmFactory
    {
        internal static UpdateMontadoraViewModel CreateInstance(UpdateMontadoraTo obj)
        {
            return new UpdateMontadoraViewModel
            {
                MontadoraId = obj.MontadoraId, Montadora = obj.Montadora, Destacar = obj.Destacar
            };
        }

        internal static IEnumerable<ListMontadoraViewModel> CreateInstance(IEnumerable<ListMontadoraTo> obj)
        {
            return obj.Select(to => new ListMontadoraViewModel
            {
                MontadoraId = to.MontadoraId, Montadora = to.Montadora, Destacar = to.Destacar
            });
        }
    }
}