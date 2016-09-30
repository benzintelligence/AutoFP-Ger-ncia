using System;
using System.Collections.Generic;
using AutoFP.Gerencia.Domain.Entities.Produto;
using AutoFP.Gerencia.Domain.ValueObjects.Resource;
using AutoFP.Gerencia.Domain.ValueObjects.Validation;
using AutoFP.Gerencia.Domain.ValueObjects.Validation.ValidationAssertion;

namespace AutoFP.Gerencia.Domain.Entities.Veiculo
{
    public class AnoModeloCarro
    {
        #region Constructor and Properties
        protected AnoModeloCarro() { }

        public AnoModeloCarro(int anoModeloCarroId)
        {
            Initialize();
            ValidateId(anoModeloCarroId);
        }

        public AnoModeloCarro(int carroId, string ano)
        {
            Initialize();
            Validate(carroId);
            ValidateAno(Convert.ToInt32(ano));
        }

        public AnoModeloCarro(int anoModeloCarroId, int ano)
        {
            Initialize();
            ValidateId(anoModeloCarroId);
            ValidateAno(ano);
        }

        public AnoModeloCarro(int anoModeloCarroId, int carroId, int ano)
        {
            Initialize();
            ValidateId(anoModeloCarroId);
            Validate(carroId);
            ValidateAno(ano);
        }

        public int AnoModeloCarroId { get; private set; }

        public int CarroId { get; private set; }

        public int Ano { get; private set; }

        public virtual Carro Carro { get; set; }

        public virtual ICollection<Peca> Pecas { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public bool IsValid => ValidationResult.IsValid;
        #endregion

        #region Methods
        private void ValidateId(int anoModeloCarroId)
        {
            if (AssertionConcern.AssertArgumentGreater(anoModeloCarroId, 0, ValidationResult, MessagesDomain.InvalidCodeCarModelGreaterThanZero))
                AnoModeloCarroId = anoModeloCarroId;
        }

        private void ValidateAno(int ano)
        {
            if (AssertionConcern.AssertArgumentYear(ano, ValidationResult, MessagesDomain.YearInvalid))
                Ano = ano;
        }

        private void Validate(int carroId)
        {
            if (AssertionConcern.AssertArgumentGreater(carroId, 0, ValidationResult, MessagesDomain.InvalidCodeCarGreaterThanZero))
                CarroId = carroId;
        }

        private void Initialize()
        {
            ValidationResult = new ValidationResult();
        }
        #endregion
    }
}