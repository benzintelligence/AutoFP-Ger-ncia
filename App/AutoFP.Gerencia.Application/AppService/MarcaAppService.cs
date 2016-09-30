using System.Collections.Generic;
using AutoFP.Gerencia.Application.AppService.Base;
using AutoFP.Gerencia.Application.Factories;
using AutoFP.Gerencia.Application.Interface;
using AutoFP.Gerencia.Application.ValueObjects.TransferObject.Marca;
using AutoFP.Gerencia.Application.ValueObjects.Validation;
using AutoFP.Gerencia.Domain.Interface.Factories;
using AutoFP.Gerencia.Domain.Interface.Services;
using AutoFP.Gerencia.Infra.Data.Interface;

namespace AutoFP.Gerencia.Application.AppService
{
    public class MarcaAppService : BaseAppService, IMarcaAppService
    {
        private readonly IMarcaService _marcaService;
        private readonly IMarcaFactory _marcaFactory;
        private readonly ICategoriaPecaFactory _categoriaPecaFactory;

        public MarcaAppService(IUnitOfWork unitOfWork, IMarcaService marcaService, IMarcaFactory marcaFactory, ICategoriaPecaFactory categoriaPecaFactory)
            : base(unitOfWork)
        {
            _marcaService = marcaService;
            _marcaFactory = marcaFactory;
            _categoriaPecaFactory = categoriaPecaFactory;
        }

        public UpdateMarcaTo GetByIdForEdit(int id)
        {
            var marca = _marcaFactory.CreateInstance(id);
            if (!marca.IsValid) return null;
            var marcaDto = _marcaService.GetByIdForEdit(marca);
            return MarcaAppFactory.CreateInstanceDirectionView(marcaDto.MarcaId, marcaDto.Marca, marcaDto.Destacar, marcaDto.CategoriaPecas);
        }

        public DetailMarcaTo GetByIdForDetail(int id)
        {
            var marca = _marcaFactory.CreateInstance(id);
            if (!marca.IsValid) return null;
            marca = _marcaService.GetByIdForDetail(marca);
            return MarcaAppFactory.CreateInstance(marca);
        }

        public IEnumerable<ListMarcaTo> GetAll(int take, int skip)
        {
            var listMarcas = _marcaService.GetAll(take, skip);
            return MarcaAppFactory.CreateListInstance(listMarcas);
        }

        public IEnumerable<ListMarcaTo> GetMarcaByCategoriaPeca(int categoriaPecaId)
        {
            var categoriaPeca = _categoriaPecaFactory.CreateInstance(categoriaPecaId);
            return MarcaAppFactory.CreateListInstance( _marcaService.GetMarcaByCategoriaPeca(categoriaPeca) );
        }

        public ValidationAppResult Add(CreateMarcaTo to)
        {
            var marca = _marcaFactory.CreateInstance(to.Descricao, to.Destacar, to.CategoriasSelecionadasIds);

            if (!marca.IsValid)
                return DomainToApplicationResult(marca.ValidationResult);

            BeginTransaction();
            _marcaService.Add(marca);
            Commit();

            BeginTransaction();
            _marcaService.AddCategories(marca);
            Commit();
            return NewValidation();
        }

        public ValidationAppResult Update(UpdateMarcaTo to)
        {
            var marca = _marcaFactory.CreateInstance(to.MarcaId, to.Descricao, to.Destacar, to.CategoriasSelecionadasIds);

            if (!marca.IsValid)
                return DomainToApplicationResult(marca.ValidationResult);

            BeginTransaction();
            _marcaService.Update(marca);
            Commit();
            return NewValidation();
        }

        public ValidationAppResult Remove(int id)
        {
            var marca = _marcaFactory.CreateInstance(id);

            if (!marca.IsValid)
                return DomainToApplicationResult(marca.ValidationResult);

            BeginTransaction();
            _marcaService.Remove(marca);
            Commit();
            return NewValidation();
        }

        public void Dispose()
        {
            _marcaService.Dispose();
        }
    }
}