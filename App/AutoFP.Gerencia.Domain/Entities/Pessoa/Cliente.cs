using System.Collections.Generic;
using AutoFP.Gerencia.Domain.Entities.Order;
using AutoFP.Gerencia.Domain.ValueObjects.Resource;
using AutoFP.Gerencia.Domain.ValueObjects.Validation;
using AutoFP.Gerencia.Domain.ValueObjects.Validation.ValidationAssertion;

namespace AutoFP.Gerencia.Domain.Entities.Pessoa
{
    public class Cliente
    {
        #region Constructors and Properties
        public Cliente() { Initialize(); }

        public Cliente(int clienteId)
        {
            Initialize();
            ValidateId(clienteId);
        }

        public int ClienteId { get; private set; }

        public virtual Pessoa Pessoa { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public bool IsValid => ValidationResult.IsValid;
        #endregion

        #region Methods
        private void ValidateId(int clienteId)
        {
            if (AssertionConcern.AssertArgumentGreater(clienteId, 0, ValidationResult, MessagesDomain.InvalidClientId))
                ClienteId = clienteId;
        }

        private void Initialize()
        {
            ValidationResult = new ValidationResult();
        }
        #endregion
    }
}