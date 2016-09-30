using System.Collections.Generic;
using AutoFP.Gerencia.Application.Factories;
using AutoFP.Gerencia.Application.ValueObjects.TransferObject.Montadora;
using AutoFP.Gerencia.MVC.UI.Factories;
using AutoFP.Gerencia.MVC.UI.ViewModel.Montadora;

namespace AutoFP.Gerencia.MVC.UI.Mapper
{
    internal static class MontadoraMappingProfile
    {
        internal static CreateMontadoraTo ViewModelToModelAdd(NewMontadoraViewModel obj)
        {
            return MontadoraAppFactory.CreateInstance(obj.Montadora, obj.Destacar);
        }

        internal static UpdateMontadoraTo ViewModelToModelUpdate(UpdateMontadoraViewModel obj)
        {
            return MontadoraAppFactory.CreateInstance(obj.MontadoraId, obj.Montadora, obj.Destacar);
        }

        internal static UpdateMontadoraViewModel ModelToViewModel(UpdateMontadoraTo obj)
        {
            return MontadoraVmFactory.CreateInstance(obj);
        }

        internal static IEnumerable<ListMontadoraViewModel> ModelToViewModel(IEnumerable<ListMontadoraTo> obj)
        {
            return MontadoraVmFactory.CreateInstance(obj);
        }
    }
}