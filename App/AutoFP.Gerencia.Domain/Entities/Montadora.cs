using System.Collections.Generic;
using AutoFP.Gerencia.Domain.Entities.Veiculo;
using AutoFP.Gerencia.Domain.ValueObjects.Resource;
using AutoFP.Gerencia.Domain.ValueObjects.Validation;
using AutoFP.Gerencia.Domain.ValueObjects.Validation.ValidationAssertion;

namespace AutoFP.Gerencia.Domain.Entities
{
    public class Montadora
    {
        #region Constructors and Properties
        protected Montadora() { }

        public Montadora(int montadoraId)
        {
            Initialize();
            ValidateId(montadoraId);
        }

        public Montadora(int montadoraId, string montadora, bool destacar)
        {
            Initialize();
            ValidateId(montadoraId);
            Validate(montadora, destacar);
        }

        public Montadora(string descricao, bool destacar)
        {
            Initialize();
            Validate(descricao, destacar);
        }

        public int MontadoraId { get; internal set; }

        public string Descricao { get; internal set; }

        public bool Destacar { get; internal set; }

        public virtual ICollection<Carro> Carros { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public bool IsValid => ValidationResult.IsValid;
        #endregion

        #region Methods
        public override string ToString()
        {
            return Descricao;
        }

        private void Validate(string montadora, bool destacar)
        {
            if (AssertionConcern.AssertArgumentLength(montadora, 2, 50, ValidationResult, MessagesDomain.InvalidManufacturerDescription))
                Descricao = montadora;

            Destacar = destacar;
        }

        private void ValidateId(int montadoraId)
        {
            if (AssertionConcern.AssertArgumentGreater(montadoraId, 0, ValidationResult, MessagesDomain.InvalidAutomobileManufacturerID))
                MontadoraId = montadoraId;
        }

        private void Initialize()
        {
            ValidationResult = new ValidationResult();
        }
        #endregion
    }
}