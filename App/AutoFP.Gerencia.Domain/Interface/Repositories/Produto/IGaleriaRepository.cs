using System;
using System.Collections.Generic;
using AutoFP.Gerencia.Domain.Entities.Produto;

namespace AutoFP.Gerencia.Domain.Interface.Repositories.Produto
{
    public interface IGaleriaRepository : IDisposable
    {
        void Add(ICollection<Galeria> galeria);
    }
}