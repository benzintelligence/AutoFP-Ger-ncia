using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoFP.Gerencia.Application.ValueObjects.TransferObject.CategoriaPeca;
using AutoFP.Gerencia.Application.ValueObjects.TransferObject.Marca;
using AutoFP.Gerencia.MVC.UI.ViewModel.Marca;

namespace AutoFP.Gerencia.MVC.UI.Factories
{
    internal static class MarcaVmFactory
    {
        internal static MultiSelectList CreateInstanceForMultiSelectList(IEnumerable<SelectListCategoriaPecaTo> listTo)
        {
            return new MultiSelectList(listTo, "CategoriaPecaId", "CategoriaDescricao");
        }

        internal static NewMarcaViewModel FillMultiSelectListForCreate (IEnumerable<SelectListCategoriaPecaTo> listTo)
        {
            return new NewMarcaViewModel { CategoriasPecas = CreateInstanceForMultiSelectList(listTo) };
        }

        internal static UpdateMarcaViewModel CreateInstance(UpdateMarcaTo obj)
        {
            return new UpdateMarcaViewModel
            {
                MarcaId = obj.MarcaId,
                Descricao = obj.Descricao,
                Destacar = obj.Destacar,
                CategoriasPecas = CreateInstanceForMultiSelectList(obj.SelectListCategoriaPecasTo)
            };
        }

        internal static DetailMarcaViewModel CreateInstance(DetailMarcaTo obj)
        {
            return new DetailMarcaViewModel
            {
                MarcaId = obj.MarcaId,
                Descricao = obj.Descricao,
                Destacar = obj.Destacar,
                ListCategoryVm = CategoriaPecaVmFactory.CreateInstance(obj.ListCategoriaPecasTo)
            };
        }

        internal static IEnumerable<ListMarcaViewModel> CreateInstance(IEnumerable<ListMarcaTo> obj)
        {
            return obj.Select(to => new ListMarcaViewModel
            {
                MarcaId = to.MarcaId,
                Descricao = to.Descricao,
                Destacar = to.Destacar
            });
        }
    }
}