using System;
using System.Collections.Generic;
using AutoFP.Gerencia.Domain.Entities.Produto;
using AutoFP.Gerencia.Domain.Interface.Repositories.Produto;
using AutoFP.Gerencia.Domain.Interface.Services.Produto;

namespace AutoFP.Gerencia.Domain.Services.Produto
{
    public class GaleriaService : IGaleriaService
    {
        private readonly IGaleriaRepository _galeriaRepository;

        public GaleriaService(IGaleriaRepository galeriaRepository)
        {
            _galeriaRepository = galeriaRepository;
        }

        public IEnumerable<Galeria> GaleriaByPecaId(Peca peca)
        {
            throw new NotImplementedException();
        }

        public void Add(ICollection<Galeria> galeria)
        {
            _galeriaRepository.Add(galeria);
        }

        public void Dispose()
        {
            _galeriaRepository.Dispose();
        }
    }
}