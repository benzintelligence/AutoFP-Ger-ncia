using System;
using System.Collections.Generic;
using AutoFP.Gerencia.Domain.Entities.Produto;
using AutoFP.Gerencia.Domain.ValueObjects.DataTransferObject;

namespace AutoFP.Gerencia.Domain.Interface.Services.Produto
{
    public interface IPecaService : IDisposable
    {
        PecaDTO FillScreenElements();

        Peca GetById(Peca peca);

        IEnumerable<Peca> GetAll(int take, int skip);

        void Add(Peca peca);

        void Update(Peca peca);

        void Remove(Peca peca);
    }
}