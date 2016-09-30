using System;
using System.Collections.Generic;
using AutoFP.Gerencia.Domain.Entities;
using AutoFP.Gerencia.Domain.Entities.Veiculo;

namespace AutoFP.Gerencia.Domain.Interface.Repositories.Veiculo
{
    public interface ICarroRepository : IDisposable
    {
        Carro GetById(Carro carro);

        IEnumerable<Carro> GetAll(int take, int skip);

        IEnumerable<Carro> GetAllByMontadora(Montadora montadora, int take, int skip);

        IEnumerable<Carro> GetAllByMontadora(Montadora montadora);

        void Add(Carro entity);

        void Update(Carro entity);

        void Remove(Carro entity);
    }
}