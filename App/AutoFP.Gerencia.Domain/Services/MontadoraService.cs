using System.Collections.Generic;
using AutoFP.Gerencia.Domain.Entities;
using AutoFP.Gerencia.Domain.Interface.Repositories;
using AutoFP.Gerencia.Domain.Interface.Services;

namespace AutoFP.Gerencia.Domain.Services
{
    public class MontadoraService : IMontadoraService
    {
        private readonly IMontadoraRepository _montadoraRepository;

        public MontadoraService(IMontadoraRepository montadoraRepository)
        {
            _montadoraRepository = montadoraRepository;
        }

        public Montadora GetById(Montadora montadora)
        {
            return _montadoraRepository.GetById(montadora);
        }

        public IEnumerable<Montadora> GetAll(int take, int skip)
        {
            return _montadoraRepository.GetAll(take, skip);
        }

        public IEnumerable<Montadora> GetAllForSelectList()
        {
            return _montadoraRepository.GetAllForSelectList();
        }

        public void Add(Montadora montadora)
        {
            _montadoraRepository.Add(montadora);
        }

        public void Update(Montadora montadora)
        {
            _montadoraRepository.Update(montadora);
        }

        public void Remove(Montadora montadora)
        {
            _montadoraRepository.Remove(montadora);
        }

        public void Dispose()
        {
            _montadoraRepository.Dispose();
        }
    }
}