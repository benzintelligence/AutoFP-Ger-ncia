using System;
using System.Collections.Generic;
using AutoFP.Gerencia.Domain.Entities;

namespace AutoFP.Gerencia.Domain.Interface.Services
{
    public interface IMontadoraService : IDisposable
    {
        Montadora GetById(Montadora montadora);

        IEnumerable<Montadora> GetAll(int take, int skip);

        IEnumerable<Montadora> GetAllForSelectList();

        void Add(Montadora montadora);

        void Update(Montadora montadora);

        void Remove(Montadora montadora);
    }
}