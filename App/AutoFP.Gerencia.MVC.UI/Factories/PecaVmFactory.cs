using System.Web.Mvc;
using AutoFP.Gerencia.Application.ValueObjects.TransferObject.Peca;
using AutoFP.Gerencia.MVC.UI.ViewModel.Peca;

namespace AutoFP.Gerencia.MVC.UI.Factories
{
    internal static class PecaVmFactory
    {
        internal static NewPecaViewModel CreateInstanceForSelectList(CreatePecaTo to)
        {
            var pecaVm = new NewPecaViewModel();

            foreach (var c in to.CategoriasPecas)
                pecaVm.CategoriasPecas.Add(new SelectListItem { Text = c.Key, Value = c.Value.ToString() });

            foreach (var ma in to.Marcas)
                pecaVm.Marcas.Add(new SelectListItem { Text = ma.Key, Value = ma.Value.ToString() });

            foreach (var mo in to.Montadoras)
                pecaVm.Montadoras.Add(new SelectListItem { Text = mo.Key, Value = mo.Value.ToString() });

            return pecaVm;
        }
    }
}