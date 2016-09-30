using AutoFP.Gerencia.Domain.ValueObjects.Resource;
using AutoFP.Gerencia.Domain.ValueObjects.Validation;
using AutoFP.Gerencia.Domain.ValueObjects.Validation.ValidationAssertion;

namespace AutoFP.Gerencia.Domain.Entities
{
    public class Email
    {
        #region Constructors and Properties
        protected Email() { }

        public Email(int emailId)
        {
            Initialize();
            ValidateId(emailId);
        }

        public Email(string email)
        {
            Initialize();
            Validate(email);
        }

        public Email(int emailId, string email)
        {
            Initialize();
            ValidateId(emailId);
            Validate(email);
        }

        public int EmailId { get; private set; }

        public string Descricao { get; private set; }

        public virtual Pessoa.Pessoa Pessoa { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public bool IsValid => ValidationResult.IsValid;
        #endregion

        #region Methods
        private void Validate(string email)
        {
            if (EmailAssertionConcern.AssertIsValid(email, ValidationResult, MessagesDomain.InvalidEmail))
                Descricao = email;
        }

        private void ValidateId(int emailId)
        {
            if (AssertionConcern.AssertArgumentGreater(emailId, 0, ValidationResult, MessagesDomain.InvalidEmailId))
                EmailId = emailId;
        }

        private void Initialize()
        {
            ValidationResult = new ValidationResult();
        }
        #endregion
    }
}