using AutoFP.Gerencia.Domain.ValueObjects.Resource;
using AutoFP.Gerencia.Domain.ValueObjects.Validation;
using AutoFP.Gerencia.Domain.ValueObjects.Validation.ValidationAssertion;

namespace AutoFP.Gerencia.Domain.Entities.Pessoa
{
    public class PessoaFisica
    {
        public PessoaFisica(string cpf, string nome, string sobrenome)
        {
            Initialize();
            Validate(cpf, nome, sobrenome);
        }

        public int PessoaFisicaId { get; set; }

        public string Cpf { get; set; }

        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public virtual Pessoa Pessoa { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public bool IsValid => ValidationResult.IsValid;

        private void Initialize()
        {
            ValidationResult = new ValidationResult();
        }

        private void Validate(string cpf, string nome, string sobrenome)
        {
            if (DocumentAssertionConcern.AssertArgumentCpf(cpf, ValidationResult, MessagesDomain.NumeroDeCpfInvalido))
                Cpf = cpf;

            if (!AssertionConcern.AssertArgumentEmpty(nome, ValidationResult, MessagesDomain.NamePerson))
                Nome = nome;

            if (!AssertionConcern.AssertArgumentEmpty(sobrenome, ValidationResult, MessagesDomain.SobrenomePerson))
                Sobrenome = sobrenome;
        }
    }
}