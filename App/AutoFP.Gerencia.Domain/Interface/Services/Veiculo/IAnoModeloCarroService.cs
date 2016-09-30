using System;
using System.Collections.Generic;
using AutoFP.Gerencia.Domain.Entities.Produto;
using AutoFP.Gerencia.Domain.Entities.Veiculo;

namespace AutoFP.Gerencia.Domain.Interface.Services.Veiculo
{
    public interface IAnoModeloCarroService : IDisposable
    {
        IEnumerable<AnoModeloCarro> GetModeloAnoByCarro(Carro carro);

        void AddAnoModeloCarroForPeca(Peca peca, IEnumerable<int> anoModelosCarrosIds);

        void AddAnoModeloCarroForCarro(Carro carro, int[] anoModelosCarrosIds);
    }
}