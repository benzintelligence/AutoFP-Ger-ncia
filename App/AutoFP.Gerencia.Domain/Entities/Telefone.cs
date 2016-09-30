using AutoFP.Gerencia.Domain.ValueObjects.Resource;
using AutoFP.Gerencia.Domain.ValueObjects.Validation;
using AutoFP.Gerencia.Domain.ValueObjects.Validation.ValidationAssertion;

namespace AutoFP.Gerencia.Domain.Entities
{
    public class Telefone
    {
        #region Constructors and Properties
        protected Telefone() { }

        public Telefone(int telefoneId)
        {
            Initialize();
            ValidateId(telefoneId);
        }

        public Telefone(int tipoTelefone, string numero)
        {
            Initialize();
            Validate(tipoTelefone, numero);
        }

        public Telefone(int telefoneId, int tipoTelefone, string numero)
        {
            Initialize();
            ValidateId(telefoneId);
            Validate(tipoTelefone, numero);
        }

        public int TelefoneId { get; private set; }

        public int TipoTelefone { get; private set; }

        public string Numero { get; private set; }

        public int PessoaId { get; private set; }

        public virtual Pessoa.Pessoa Pessoa { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public bool IsValid => ValidationResult.IsValid;
        #endregion

        #region Methods
        private void Validate(int tipoTelefone, string numero)
        {
            if (AssertionConcern.AssertArgumentRangeNumeric(tipoTelefone, (int)ValueObjects.Enums.TipoTelefone.Fixo, (int)ValueObjects.Enums.TipoTelefone.Celular, ValidationResult, MessagesDomain.TelephoneRelationshipId))
                TipoTelefone = tipoTelefone;

            var number = AssertionConcern.OnlyNumbers(numero);

            if (!AssertionConcern.AssertArgumentLength(number, 10, 11, ValidationResult, MessagesDomain.InvalidTelephone))
                return;

            if ((TipoTelefone.Equals(1) && number.Length.Equals(10)) || (TipoTelefone.Equals(2) && number.Length.Equals(11)) )
                Numero = number;
            else
                ValidationResult.AddError(MessagesDomain.TelephoneLength);
        }

        private void ValidateId(int telefoneId)
        {
            if (AssertionConcern.AssertArgumentGreater(telefoneId, 0, ValidationResult, MessagesDomain.InvalidTelephoneId))
                TelefoneId = telefoneId;
        }

        private void Initialize()
        {
            ValidationResult = new ValidationResult();
        }
        #endregion
    }
}