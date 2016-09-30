using System;
using AutoFP.Gerencia.Domain.Entities.Produto;
using AutoFP.Gerencia.Domain.ValueObjects.DataTransferObject;

namespace AutoFP.Gerencia.Domain.Interface.Repositories.Produto
{
    public interface IPecaRepository : IDisposable
    {
        PecaDTO FillScreenElements();

        void Add(Peca peca);
    }
}