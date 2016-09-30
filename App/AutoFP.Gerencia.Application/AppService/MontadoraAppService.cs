using System.Collections.Generic;
using AutoFP.Gerencia.Application.AppService.Base;
using AutoFP.Gerencia.Application.Factories;
using AutoFP.Gerencia.Application.Interface;
using AutoFP.Gerencia.Application.ValueObjects.TransferObject.Montadora;
using AutoFP.Gerencia.Application.ValueObjects.Validation;
using AutoFP.Gerencia.Domain.Interface.Factories;
using AutoFP.Gerencia.Domain.Interface.Services;
using AutoFP.Gerencia.Infra.Data.Interface;

namespace AutoFP.Gerencia.Application.AppService
{
    public class MontadoraAppService : BaseAppService, IMontadoraAppService
    {
        private readonly IMontadoraService _montadoraService;
        private readonly IMontadoraFactory _montadoraFactory;

        public MontadoraAppService(IUnitOfWork unitOfWork, IMontadoraService montadoraService, IMontadoraFactory montadoraFactory)
            : base(unitOfWork)
        {
            _montadoraFactory = montadoraFactory;
            _montadoraService = montadoraService;
        }

        public UpdateMontadoraTo GetById(int id)
        {
            var montadora = _montadoraFactory.CreateInstance(id);
            if (!montadora.IsValid) return null;
            montadora = _montadoraService.GetById(montadora);
            return MontadoraAppFactory.CreateInstance(montadora.MontadoraId, montadora.Descricao, montadora.Destacar);
        }

        public IEnumerable<ListMontadoraTo> GetAllForSelectList()
        {
            var listMontadora = _montadoraService.GetAllForSelectList();
            return MontadoraAppFactory.CreateListInstance(listMontadora);
        }

        public IEnumerable<ListMontadoraTo> GetAll(int take, int skip)
        {
            var listMontadora = _montadoraService.GetAll(take, skip);
            return MontadoraAppFactory.CreateListInstance(listMontadora);
        }

        public ValidationAppResult Add(CreateMontadoraTo to)
        {
            var montadora = _montadoraFactory.CreateInstance(to.Montadora, to.Destacar);

            if (!montadora.IsValid)
                return DomainToApplicationResult(montadora.ValidationResult);

            BeginTransaction();
            _montadoraService.Add(montadora);
            Commit();

            return NewValidation();
        }

        public ValidationAppResult Update(UpdateMontadoraTo to)
        {
            var montadora = _montadoraFactory.CreateInstance(to.MontadoraId, to.Montadora, to.Destacar);

            if (!montadora.IsValid)
                return DomainToApplicationResult(montadora.ValidationResult);

            BeginTransaction();
            _montadoraService.Update(montadora);
            Commit();

            return NewValidation();
        }

        public ValidationAppResult Remove(int id)
        {
            var montadora = _montadoraFactory.CreateInstance(id);

            if (!montadora.IsValid)
                return DomainToApplicationResult(montadora.ValidationResult);

            BeginTransaction();
            _montadoraService.Remove(montadora);
            Commit();

            return NewValidation();
        }

        public void Dispose()
        {
            _montadoraService.Dispose();
        }
    }
}