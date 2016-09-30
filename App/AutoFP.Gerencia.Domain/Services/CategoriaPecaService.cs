using System.Collections.Generic;
using AutoFP.Gerencia.Domain.Entities;
using AutoFP.Gerencia.Domain.Interface.Repositories;
using AutoFP.Gerencia.Domain.Interface.Services;

namespace AutoFP.Gerencia.Domain.Services
{
    public class CategoriaPecaService : ICategoriaPecaService
    {
        private readonly ICategoriaPecaRepository _categoriaPecaRepository;

        public CategoriaPecaService(ICategoriaPecaRepository categoriaPecaRepository)
        {
            _categoriaPecaRepository = categoriaPecaRepository;
        }

        public CategoriaPeca GetById(CategoriaPeca categoriaPeca)
        {
            return _categoriaPecaRepository.GetById(categoriaPeca);
        }

        public IEnumerable<CategoriaPeca> ObterCategoriasPecasParaListaSelecionar()
        {
            return _categoriaPecaRepository.ObterCategoriasPecasParaListaSelecionar();
        }

        public IEnumerable<CategoriaPeca> GetAll(int take, int skip)
        {
            return _categoriaPecaRepository.GetAll(take, skip);
        }

        public void Add(CategoriaPeca categoriaPeca)
        {
            _categoriaPecaRepository.Add(categoriaPeca);
        }

        public void Update(CategoriaPeca categoriaPeca)
        {
            _categoriaPecaRepository.Update(categoriaPeca);
        }

        public void Remove(CategoriaPeca categoriaPeca)
        {
            _categoriaPecaRepository.Remove(categoriaPeca);
        }

        public void Dispose()
        {
            _categoriaPecaRepository.Dispose();
        }
    }
}