using System.Collections.Generic;
using AutoFP.Gerencia.Application.AppService.Base;
using AutoFP.Gerencia.Application.Factories;
using AutoFP.Gerencia.Application.Interface;
using AutoFP.Gerencia.Application.ValueObjects.TransferObject.CategoriaPeca;
using AutoFP.Gerencia.Application.ValueObjects.Validation;
using AutoFP.Gerencia.Domain.Interface.Factories;
using AutoFP.Gerencia.Domain.Interface.Services;
using AutoFP.Gerencia.Infra.Data.Interface;

namespace AutoFP.Gerencia.Application.AppService
{
    public class CategoriaPecaAppService : BaseAppService, ICategoriaPecaAppService
    {
        private readonly ICategoriaPecaService _categoriaPecaService;
        private readonly ICategoriaPecaFactory _categoriaPecaFactory;

        public CategoriaPecaAppService(IUnitOfWork unitOfWork, ICategoriaPecaService categoriaPecaService, ICategoriaPecaFactory categoriaPecaFactory)
            : base(unitOfWork)
        {
            _categoriaPecaService = categoriaPecaService;
            _categoriaPecaFactory = categoriaPecaFactory;
        }

        public UpdateCategoriaPecaTo GetById(int id)
        {
            var categoriaPeca = _categoriaPecaFactory.CreateInstance(id);
            if (!categoriaPeca.IsValid) return null;
            categoriaPeca = _categoriaPecaService.GetById(categoriaPeca);
            return CategoriaPecaAppFactory.CreateInstance(categoriaPeca.CategoriaPecaId, categoriaPeca.Categoria);
        }

        public IEnumerable<SelectListCategoriaPecaTo> ObterCategoriasPecasParaListaSelecionar()
        {
            var listCategoriaPeca = _categoriaPecaService.ObterCategoriasPecasParaListaSelecionar();
            return CategoriaPecaAppFactory.CreateSelectListInstance(listCategoriaPeca);
        }

        public IEnumerable<ListCategoriaPecaTo> GetAll(int take, int skip)
        {
            var listCategoriaPeca = _categoriaPecaService.GetAll(take, skip);
            return CategoriaPecaAppFactory.CreateListInstance(listCategoriaPeca);
        }

        public ValidationAppResult Add(CreateCategoriaPecaTo to)
        {
            var categoriaPeca = _categoriaPecaFactory.CreateInstance(to.Descricao);
            if (!categoriaPeca.IsValid)
                DomainToApplicationResult(categoriaPeca.ValidationResult);

            BeginTransaction();
            _categoriaPecaService.Add(categoriaPeca);
            Commit();
            return NewValidation();
        }

        public ValidationAppResult Update(UpdateCategoriaPecaTo to)
        {
            var categoriaPeca = _categoriaPecaFactory.CreateInstance(to.CategoriaPecaId, to.Descricao);
            if (!categoriaPeca.IsValid)
                DomainToApplicationResult(categoriaPeca.ValidationResult);

            BeginTransaction();
            _categoriaPecaService.Update(categoriaPeca);
            Commit();
            return NewValidation();
        }

        public ValidationAppResult Remove(int id)
        {
            var categoriaPeca = _categoriaPecaFactory.CreateInstance(id);

            if (!categoriaPeca.IsValid)
                return DomainToApplicationResult(categoriaPeca.ValidationResult);

            BeginTransaction();
            _categoriaPecaService.Remove(categoriaPeca);
            Commit();
            return NewValidation();
        }

        public void Dispose()
        {
            _categoriaPecaService.Dispose();
        }
    }
}