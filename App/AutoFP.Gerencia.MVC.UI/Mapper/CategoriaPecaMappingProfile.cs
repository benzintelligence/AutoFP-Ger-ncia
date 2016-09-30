using System.Collections.Generic;
using AutoFP.Gerencia.Application.Factories;
using AutoFP.Gerencia.Application.ValueObjects.TransferObject.CategoriaPeca;
using AutoFP.Gerencia.MVC.UI.Factories;
using AutoFP.Gerencia.MVC.UI.ViewModel.CategoriaPeca;

namespace AutoFP.Gerencia.MVC.UI.Mapper
{
    internal static class CategoriaPecaMappingProfile
    {
        internal static CreateCategoriaPecaTo ViewModelToModelAdd(NewCategoriaPecaViewModel obj)
        {
            return CategoriaPecaAppFactory.CreateInstance(obj.Descricao);
        }

        internal static UpdateCategoriaPecaTo ViewModelToModelUpdate(UpdateCategoriaPecaViewModel obj)
        {
            return CategoriaPecaAppFactory.CreateInstance(obj.CategoriaPecaId, obj.Descricao);
        }

        internal static UpdateCategoriaPecaViewModel ModelToViewModel(UpdateCategoriaPecaTo obj)
        {
            return CategoriaPecaVmFactory.CreateInstance(obj);
        }

        internal static IEnumerable<ListCategoriaPecaViewModel> ModelToViewModel(IEnumerable<ListCategoriaPecaTo> obj)
        {
            return CategoriaPecaVmFactory.CreateInstance(obj);
        }
    }
}