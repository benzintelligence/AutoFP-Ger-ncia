using AutoFP.Gerencia.Application.Interface.Base;
using AutoFP.Gerencia.Application.ValueObjects.Validation;
using AutoFP.Gerencia.Domain.ValueObjects.Validation;
using AutoFP.Gerencia.Infra.Data.Interface;

namespace AutoFP.Gerencia.Application.AppService.Base
{
    public class BaseAppService : IBaseAppService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BaseAppService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void BeginTransaction()
        {
            _unitOfWork.BeginTransaction();
        }

        public void Commit()
        {
            _unitOfWork.SaveChanges();
        }

        protected ValidationAppResult DomainToApplicationResult(ValidationResult obj)
        {
            var validationApp = NewValidation();
            validationApp.AddErrors(obj);
            return validationApp;
        }

        protected ValidationAppResult NewValidation()
        {
            return new ValidationAppResult();
        }
    }
}