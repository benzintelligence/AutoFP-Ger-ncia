using System.Collections.Generic;
using AutoFP.Gerencia.Domain.Entities.Produto;
using AutoFP.Gerencia.Domain.ValueObjects.Resource;
using AutoFP.Gerencia.Domain.ValueObjects.Validation;
using AutoFP.Gerencia.Domain.ValueObjects.Validation.ValidationAssertion;

namespace AutoFP.Gerencia.Domain.Entities
{
    public class CategoriaPeca
    {
        #region Constructors and Properties
        protected CategoriaPeca() { }

        public CategoriaPeca(int categoriaPecaId)
        {
            Initialize();
            ValidateId(categoriaPecaId);
        }

        public CategoriaPeca(string descricao)
        {
            Initialize();
            Validate(descricao);
        }

        public CategoriaPeca(int categoriaPecaId, string descricao)
        {
            Initialize();
            ValidateId(categoriaPecaId);
            Validate(descricao);
        }

        public int CategoriaPecaId { get; private set; }

        public string Categoria { get; private set; }

        public virtual ICollection<Peca> Pecas { get; set; }

        public virtual ICollection<Marca> Marcas { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public bool IsValid => ValidationResult.IsValid;
        #endregion

        #region Methods
        private void Validate(string descricaoTipoPeca)
        {
            if (AssertionConcern.AssertArgumentLength(descricaoTipoPeca, 2, 50, ValidationResult, MessagesDomain.CategoryPieceInvalid))
                Categoria = descricaoTipoPeca;
        }

        private void ValidateId(int categoriaPecaId)
        {
            if (AssertionConcern.AssertArgumentGreater(categoriaPecaId, 0, ValidationResult, MessagesDomain.CategoryPieceIdInvalid))
                CategoriaPecaId = categoriaPecaId;
        }

        private void Initialize()
        {
            ValidationResult = new ValidationResult();
        }
        #endregion
    }
}