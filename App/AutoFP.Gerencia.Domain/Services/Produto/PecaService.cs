using System;
using System.Collections.Generic;
using AutoFP.Gerencia.Domain.Entities.Produto;
using AutoFP.Gerencia.Domain.Interface.Repositories.Produto;
using AutoFP.Gerencia.Domain.Interface.Services.Produto;
using AutoFP.Gerencia.Domain.ValueObjects.DataTransferObject;

namespace AutoFP.Gerencia.Domain.Services.Produto
{
    public class PecaService : IPecaService
    {
        private readonly IPecaRepository _pecaRepository;

        public PecaService(IPecaRepository pecaRepository)
        {
            _pecaRepository = pecaRepository;
        }

        public PecaDTO FillScreenElements()
        {
            return _pecaRepository.FillScreenElements();
        }

        public Peca GetById(Peca peca)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Peca> GetAll(int take, int skip)
        {
            throw new NotImplementedException();
        }

        public void Add(Peca peca)
        {
            _pecaRepository.Add(peca);
        }

        public void Update(Peca peca)
        {
            throw new NotImplementedException();
        }

        public void Remove(Peca peca)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _pecaRepository.Dispose();
        }
    }
}