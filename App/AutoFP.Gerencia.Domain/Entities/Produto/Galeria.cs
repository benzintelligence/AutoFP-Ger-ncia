using AutoFP.Gerencia.Domain.ValueObjects.Resource;
using AutoFP.Gerencia.Domain.ValueObjects.Validation;
using AutoFP.Gerencia.Domain.ValueObjects.Validation.ValidationAssertion;

namespace AutoFP.Gerencia.Domain.Entities.Produto
{
    public class Galeria
    {
        #region Constructor and Properties
        protected Galeria() { }

        public Galeria(int galeriaId)
        {
            Initialize();
            ValidateId(galeriaId);
        }

        public Galeria(int pecaId, string imageUrl)
        {
            Initialize();
            Validate(pecaId, imageUrl);
        }

        public Galeria(int galeriaId, int pecaId, string imageUrl)
        {
            Initialize();
            ValidateId(galeriaId);
            Validate(pecaId, imageUrl);
        }

        public int GaleriaId { get; private set; }

        public int PecaId { get; private set; }

        public string ImageLink { get; private set; }

        public virtual Peca Peca { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public bool IsValid => ValidationResult.IsValid;
        #endregion

        #region Methods
        private void Validate(int pecaId, string imageUrl)
        {
            if (AssertionConcern.AssertArgumentGreater(pecaId, 0, ValidationResult, MessagesDomain.InvalidCodeGaleryToPieceGreaterThanZero))
                PecaId = pecaId;

            ImageLink = imageUrl;
        }

        private void ValidateId(int galeriaId)
        {
            if (AssertionConcern.AssertArgumentGreater(galeriaId, 0, ValidationResult, MessagesDomain.InvalidGaleryId))
                GaleriaId = galeriaId;
        }

        private void Initialize()
        {
            ValidationResult = new ValidationResult();
        }
        #endregion
    }
}