using System;
using System.Collections.Generic;
using AutoFP.Gerencia.Domain.Entities;
using AutoFP.Gerencia.Domain.ValueObjects.DataTransferObject;

namespace AutoFP.Gerencia.Domain.Interface.Repositories
{
    public interface IMarcaRepository : IDisposable
    {
        MarcaDTO GetByIdForEdit(Marca marca);

        Marca GetByIdForDetail(Marca marca);

        IEnumerable<Marca> GetAll(int take, int skip);

        IEnumerable<Marca> GetMarcaByCategoriaPeca(CategoriaPeca categoriaPeca);

        void Add(Marca marca);

        void AddCategories(Marca marca);

        void Update(Marca marca);

        void Remove(Marca marca);
    }
}