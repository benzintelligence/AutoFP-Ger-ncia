using System;
using System.Collections.Generic;
using AutoFP.Gerencia.Domain.Entities;

namespace AutoFP.Gerencia.Domain.Interface.Repositories
{
    public interface IMontadoraRepository : IDisposable
    {
        IEnumerable<Montadora> GetAll(int take, int skip);

        IEnumerable<Montadora> GetAllForSelectList();

        Montadora GetById(Montadora montadora);

        void Add(Montadora montadora);

        void Update(Montadora montadora);

        void Remove(Montadora montadora);
    }
}