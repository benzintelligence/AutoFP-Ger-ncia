using System.Collections.Generic;
using AutoFP.Gerencia.Domain.Entities.Produto;
using AutoFP.Gerencia.Domain.ValueObjects.Resource;
using AutoFP.Gerencia.Domain.ValueObjects.Validation;
using AutoFP.Gerencia.Domain.ValueObjects.Validation.ValidationAssertion;

namespace AutoFP.Gerencia.Domain.Entities.Pessoa
{
    public class Fornecedor
    {
        #region Constructors and Properties

        public Fornecedor() { Initialize(); }

        public Fornecedor(int fornecedorId)
        {
            Initialize();
            ValidateId(fornecedorId);
        }

        public int FornecedorId { get; private set; }

        public virtual Pessoa Pessoa { get; set; }

        public virtual ICollection<Peca> Pecas { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public bool IsValid => ValidationResult.IsValid;
        #endregion

        #region Methods
        private void ValidateId(int fornecedorId)
        {
            if (AssertionConcern.AssertArgumentGreater(fornecedorId, 0, ValidationResult, MessagesDomain.InvalidProviderId))
                FornecedorId = fornecedorId;
        }

        private void Initialize()
        {
            ValidationResult = new ValidationResult();
        }
        #endregion
    }
}