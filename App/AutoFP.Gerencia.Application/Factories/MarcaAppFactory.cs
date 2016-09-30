using System.Collections.Generic;
using System.Linq;
using AutoFP.Gerencia.Application.ValueObjects.TransferObject.Marca;
using AutoFP.Gerencia.Domain.Entities;

namespace AutoFP.Gerencia.Application.Factories
{
    public static class MarcaAppFactory
    {
        public static CreateMarcaTo CreateInstance(string descricao, bool destacar, int[] categoriasIdsSelecionadas)
        {
            return new CreateMarcaTo { Descricao = descricao, Destacar = destacar, CategoriasSelecionadasIds = categoriasIdsSelecionadas };
        }

        public static UpdateMarcaTo CreateInstance(int marcaId, string descricao, bool destacar, int[] categoriasIdsSelecionadas)
        {
            return new UpdateMarcaTo { MarcaId = marcaId, Descricao = descricao, Destacar = destacar, CategoriasSelecionadasIds = categoriasIdsSelecionadas };
        }

        public static UpdateMarcaTo CreateInstanceDirectionView(int marcaId, string descricao, bool destacar, IEnumerable<CategoriaPeca> categoriaPecas = null)
        {
            return new UpdateMarcaTo
            {
                MarcaId = marcaId,
                Descricao = descricao,
                Destacar = destacar,
                SelectListCategoriaPecasTo = categoriaPecas == null ? null : CategoriaPecaAppFactory.CreateSelectListInstance(categoriaPecas)
            };
        }

        public static DetailMarcaTo CreateInstance(Marca marca)
        {
            return new DetailMarcaTo
            {
                MarcaId = marca.MarcaId,
                Descricao = marca.Descricao,
                Destacar = marca.Destacar,
                ListCategoriaPecasTo = CategoriaPecaAppFactory.CreateListInstance(marca.CategoriaPecas)
            };
        }

        public static IEnumerable<ListMarcaTo> CreateListInstance(IEnumerable<Marca> listMarca)
        {
            return listMarca.Select(m => new ListMarcaTo
            {
                MarcaId = m.MarcaId, Descricao = m.Descricao, Destacar = m.Destacar
            });
        }
    }
}