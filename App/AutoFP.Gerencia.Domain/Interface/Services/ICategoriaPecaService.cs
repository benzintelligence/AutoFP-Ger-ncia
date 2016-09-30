using System;
using System.Collections.Generic;
using AutoFP.Gerencia.Domain.Entities;

namespace AutoFP.Gerencia.Domain.Interface.Services
{
    public interface ICategoriaPecaService : IDisposable
    {
        CategoriaPeca GetById(CategoriaPeca categoriaPeca);

        IEnumerable<CategoriaPeca> ObterCategoriasPecasParaListaSelecionar();

        IEnumerable<CategoriaPeca> GetAll(int take, int skip);

        void Add(CategoriaPeca categoriaPeca);

        void Update(CategoriaPeca categoriaPeca);

        void Remove(CategoriaPeca categoriaPeca);
    }
}