using System;
using System.Collections.Generic;
using AutoFP.Gerencia.Domain.Entities;
using AutoFP.Gerencia.Domain.Entities.Veiculo;
using AutoFP.Gerencia.Domain.Interface.Repositories.Veiculo;
using AutoFP.Gerencia.Domain.Interface.Services.Veiculo;

namespace AutoFP.Gerencia.Domain.Services.Veiculo
{
    public class CarroService : ICarroService
    {
        private readonly ICarroRepository _carroRepository;

        public CarroService(ICarroRepository carroRepository)
        {
            _carroRepository = carroRepository;
        }

        public Carro GetById(Carro carro)
        {
            return _carroRepository.GetById(carro);
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
            _carroRepository.Dispose();
        }
    }
}