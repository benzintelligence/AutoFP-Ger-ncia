using System;
using System.Collections.Generic;
using AutoFP.Gerencia.Domain.Entities;

namespace AutoFP.Gerencia.Domain.Interface.Repositories
{
    public interface ICategoriaPecaRepository : IDisposable
    {
        IEnumerable<CategoriaPeca> ObterCategoriasPecasParaListaSelecionar();

        IEnumerable<CategoriaPeca> GetAll(int take, int skip);

        CategoriaPeca GetById(CategoriaPeca categoriaPeca);

        void Add(CategoriaPeca categoriaPeca);

        void Update(CategoriaPeca categoriaPeca);

        void Remove(CategoriaPeca categoriaPeca);
    }
}