using System.Collections.Generic;
using AutoFP.Gerencia.Domain.ValueObjects.Helpers;
using AutoFP.Gerencia.Domain.ValueObjects.Resource;
using AutoFP.Gerencia.Domain.ValueObjects.Validation;
using AutoFP.Gerencia.Domain.ValueObjects.Validation.ValidationAssertion;

namespace AutoFP.Gerencia.Domain.Entities.Veiculo
{
    public class Carro
    {
        #region Constructor and Properties
        protected Carro() { }

        public Carro(int carroId)
        {
            Initialize();
            ValidateId(carroId);
        }

        public Carro(string nome, int montadoraId)
        {
            Initialize();
            Validate(nome);
            ValidateMontadoraId(montadoraId);
        }

        public Carro(int carroId, string nome)
        {
            Initialize();
            ValidateId(carroId);
            Validate(nome);
        }

        public Carro(int carroId, string nome, int montadoraId)
        {
            Initialize();
            ValidateId(carroId);
            Validate(nome);
            ValidateMontadoraId(montadoraId);
        }

        public int CarroId { get; private set; }

        public string Nome { get; private set; }

        public int MontadoraId { get; private set; }

        public virtual Montadora Montadora { get; set; }

        public virtual ICollection<AnoModeloCarro> AnoModeloCarros { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public bool IsValid => ValidationResult.IsValid;
        #endregion

        #region Methods
        private void Validate(string nome)
        {
            if (AssertionConcern.AssertArgumentLength(nome, 1, 50, ValidationResult, MessagesDomain.CarNameInvalid))
                Nome = nome;
        }

        private void ValidateMontadoraId(int montadoraId)
        {
            if (AssertionConcern.AssertArgumentGreater(montadoraId, 0, ValidationResult, MessagesDomain.InvalidManufacturerToCarCodeGreaterThanZero))
                MontadoraId = montadoraId;
        }

        private void ValidateId(int carroId)
        {
            if (AssertionConcern.AssertArgumentGreater(carroId, 0, ValidationResult, MessagesDomain.InvalidCodeCarGreaterThanZero))
                CarroId = carroId;
        }

        public void ValidarModelosAnosDoVeiculo(int[] anosModelos)
        {
            for (var i = 0; i < anosModelos.Length; i++)
            {
                if (anosModelos[i] >= AnoHelper.AnoMinimo && anosModelos[i] <= AnoHelper.AnoMaximo) continue;

                ValidationResult.AddError(string.Format(MessagesDomain.InvalidCarModelYearInterval, AnoHelper.AnoMinimo, AnoHelper.AnoMaximo));
                break;
            }
        }

        private void Initialize()
        {
            ValidationResult = new ValidationResult();
        }
        #endregion
    }
}