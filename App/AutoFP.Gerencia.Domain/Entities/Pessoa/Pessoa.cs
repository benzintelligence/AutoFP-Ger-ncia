using System;
using System.Collections.Generic;
using AutoFP.Gerencia.Domain.Entities.Localizacao;
using AutoFP.Gerencia.Domain.ValueObjects.Resource;
using AutoFP.Gerencia.Domain.ValueObjects.Validation;
using AutoFP.Gerencia.Domain.ValueObjects.Validation.ValidationAssertion;

namespace AutoFP.Gerencia.Domain.Entities.Pessoa
{
    public class Pessoa
    {
        #region Constructors and Properties
        protected Pessoa() { }

        public Pessoa(int? pessoaId = 0)
        {
            Initialize();
            ValidateId((int)pessoaId);
        }

        public Pessoa(int tipoPessoa)
        {
            Initialize();
            Validate(tipoPessoa);
        }

        public Pessoa(int pessoaId, int tipoPessoa)
        {
            Initialize();
            ValidateId(pessoaId);
            Validate(tipoPessoa);
        }

        public int PessoaId { get; private set; }

        public int TipoPessoa { get; private set; }

        public DateTime DataRegistro { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual Email Email { get; set; }

        public virtual Fornecedor Fornecedor { get; set; }

        public virtual PessoaJuridica PessoaJuridica { get; set; }

        public virtual PessoaFisica PessoaFisica { get; set; }

        public virtual ICollection<Endereco> Enderecos { get; set; }

        public virtual ICollection<Telefone> Telefones { get; set; }

        public virtual Usuario Usuario { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public bool IsValid => ValidationResult.IsValid;
        #endregion

        #region Methods
        private void Validate(int tipoPessoa)
        {
            if (AssertionConcern.AssertArgumentRangeNumeric(tipoPessoa, (int)ValueObjects.Enums.TipoPessoa.PersonPhysical, (int)ValueObjects.Enums.TipoPessoa.PersonJuridical, ValidationResult, MessagesDomain.InvalidTypePerson))
                TipoPessoa = tipoPessoa;
        }

        private void ValidateId(int pessoaId)
        {
            if (AssertionConcern.AssertArgumentGreater(pessoaId, 0, ValidationResult, MessagesDomain.InvalidPersonId))
                PessoaId = pessoaId;
        }

        private void Initialize()
        {
            ValidationResult = new ValidationResult();
        }
        #endregion
    }
}