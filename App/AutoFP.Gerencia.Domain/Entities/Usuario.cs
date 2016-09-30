using AutoFP.Gerencia.Domain.ValueObjects.Resource;
using AutoFP.Gerencia.Domain.ValueObjects.Validation;
using AutoFP.Gerencia.Domain.ValueObjects.Validation.ValidationAssertion;

namespace AutoFP.Gerencia.Domain.Entities
{
    public class Usuario
    {
        public Usuario() { Initialize(); }

        public int UsuarioId { get; set; }

        public string Email { get; set; }

        public bool EmailConfirmado { get; set; }

        public string SenhaHash { get; set; }

        public bool IsUserManagement { get; set; }

        public virtual Pessoa.Pessoa Pessoa { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public bool IsValid => ValidationResult.IsValid;

        private void Initialize()
        {
            ValidationResult = new ValidationResult();
        }

        public void PreencherInformacoesParaLogin(string login, string senha)
        {
            if (EmailAssertionConcern.AssertIsValid(login, ValidationResult, MessagesDomain.InvalidEmail))
                Email = login;

            if (!AssertionConcern.AssertArgumentEmpty(senha, ValidationResult, MessagesDomain.PasswordEmpty))
                SenhaHash = PasswordAssertionConcern.Encrypt(senha);
        }
    }
}