using System;
using System.Collections.Generic;
using AutoFP.Gerencia.Domain.Entities.Produto;

namespace AutoFP.Gerencia.Domain.Interface.Services.Produto
{
    public interface IGaleriaService : IDisposable
    {
        IEnumerable<Galeria> GaleriaByPecaId(Peca peca);

        void Add(ICollection<Galeria> galeria);
    }
}