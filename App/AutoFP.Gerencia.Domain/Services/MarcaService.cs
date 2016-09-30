using System.Collections.Generic;
using AutoFP.Gerencia.Domain.Entities;
using AutoFP.Gerencia.Domain.Interface.Repositories;
using AutoFP.Gerencia.Domain.Interface.Services;
using AutoFP.Gerencia.Domain.ValueObjects.DataTransferObject;

namespace AutoFP.Gerencia.Domain.Services
{
    public class MarcaService : IMarcaService
    {
        private readonly IMarcaRepository _marcaRepository;

        public MarcaService(IMarcaRepository marcaRepository)
        {
            _marcaRepository = marcaRepository;
        }

        public MarcaDTO GetByIdForEdit(Marca marca)
        {
            return _marcaRepository.GetByIdForEdit(marca);
        }

        public Marca GetByIdForDetail(Marca marca)
        {
            return _marcaRepository.GetByIdForDetail(marca);
        }

        public IEnumerable<Marca> GetAll(int take, int skip)
        {
            return _marcaRepository.GetAll(take, skip);
        }

        public IEnumerable<Marca> GetMarcaByCategoriaPeca(CategoriaPeca categoriaPeca)
        {
            return _marcaRepository.GetMarcaByCategoriaPeca(categoriaPeca);
        }

        public void Add(Marca marca)
        {
            _marcaRepository.Add(marca);
        }

        public void AddCategories(Marca marca)
        {
            _marcaRepository.AddCategories(marca);
        }

        public void Update(Marca marca)
        {
            _marcaRepository.Update(marca);
        }

        public void Remove(Marca marca)
        {
            _marcaRepository.Remove(marca);
        }

        public void Dispose()
        {
            _marcaRepository.Dispose();
        }
    }
}