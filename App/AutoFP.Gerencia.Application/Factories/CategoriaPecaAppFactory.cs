using System.Collections.Generic;
using System.Linq;
using AutoFP.Gerencia.Application.ValueObjects.TransferObject.CategoriaPeca;
using AutoFP.Gerencia.Domain.Entities;

namespace AutoFP.Gerencia.Application.Factories
{
    public static class CategoriaPecaAppFactory
    {
        public static CreateCategoriaPecaTo CreateInstance(string descricao)
        {
            return new CreateCategoriaPecaTo { Descricao = descricao };
        }

        public static UpdateCategoriaPecaTo CreateInstance(int categoriaPecaId, string descricao)
        {
            return new UpdateCategoriaPecaTo { CategoriaPecaId = categoriaPecaId, Descricao = descricao };
        }

        public static IEnumerable<ListCategoriaPecaTo> CreateListInstance(IEnumerable<CategoriaPeca> listCategoriaPecas)
        {
            return listCategoriaPecas.Select(cp => new ListCategoriaPecaTo
            {
                CategoriaPecaId = cp.CategoriaPecaId,
                Descricao = cp.Categoria
            });
        }

        public static IEnumerable<SelectListCategoriaPecaTo> CreateSelectListInstance(IEnumerable<CategoriaPeca> listCategoriaPecas)
        {
            return listCategoriaPecas.Select(cp => new SelectListCategoriaPecaTo
            {
                CategoriaPecaId = cp.CategoriaPecaId,
                CategoriaDescricao = cp.Categoria
            });
        }
    }
}