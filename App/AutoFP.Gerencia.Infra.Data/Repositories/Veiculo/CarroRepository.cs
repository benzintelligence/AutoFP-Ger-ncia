using System;
using System.Collections.Generic;
using AutoFP.Gerencia.Domain.Entities;
using AutoFP.Gerencia.Domain.Entities.Veiculo;
using AutoFP.Gerencia.Domain.Interface.Repositories.Veiculo;
using AutoFP.Gerencia.Infra.Data.Context;

namespace AutoFP.Gerencia.Infra.Data.Repositories.Veiculo
{
    public class CarroRepository : ICarroRepository
    {
        private readonly AutoFpContext _context;

        public CarroRepository(AutoFpContext context)
        {
            _context = context;
        }

        public Carro GetById(Carro carro)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Carro> GetAll(int take, int skip)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Carro> GetAllByMontadora(Montadora montadora, int take, int skip)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Carro> GetAllByMontadora(Montadora montadora)
        {
            throw new NotImplementedException();
        }

        public void Add(Carro entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Carro entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(Carro entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}