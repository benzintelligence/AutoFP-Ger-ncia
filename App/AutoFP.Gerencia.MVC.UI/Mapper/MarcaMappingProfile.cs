using System.Collections.Generic;
using AutoFP.Gerencia.Application.Factories;
using AutoFP.Gerencia.Application.ValueObjects.TransferObject.Marca;
using AutoFP.Gerencia.MVC.UI.Factories;
using AutoFP.Gerencia.MVC.UI.ViewModel.Marca;

namespace AutoFP.Gerencia.MVC.UI.Mapper
{
    internal static class MarcaMappingProfile
    {
        internal static CreateMarcaTo ViewModelToModelAdd(NewMarcaViewModel obj)
        {
            return MarcaAppFactory.CreateInstance(obj.Descricao, obj.Destacar, obj.CategoriasIdsSelecionadas);
        }

        internal static UpdateMarcaTo ViewModelToModelUpdate(UpdateMarcaViewModel obj)
        {
            return MarcaAppFactory.CreateInstance(obj.MarcaId, obj.Descricao, obj.Destacar, obj.CategoriasIdsSelecionadas);
        }

        internal static DetailMarcaViewModel ModelToViewModelDetail(DetailMarcaTo obj)
        {
            return MarcaVmFactory.CreateInstance(obj);
        }

        internal static UpdateMarcaViewModel ModelToViewModel(UpdateMarcaTo obj)
        {
            var viewModel = MarcaVmFactory.CreateInstance(obj);
            return viewModel;
        }

        internal static IEnumerable<ListMarcaViewModel> ModelToViewModel(IEnumerable<ListMarcaTo> obj)
        {
            return MarcaVmFactory.CreateInstance(obj);
        }
    }
}