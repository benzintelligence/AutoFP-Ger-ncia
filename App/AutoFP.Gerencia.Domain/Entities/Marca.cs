using System.Collections.Generic;
using AutoFP.Gerencia.Domain.Entities.Produto;
using AutoFP.Gerencia.Domain.ValueObjects.Resource;
using AutoFP.Gerencia.Domain.ValueObjects.Validation;
using AutoFP.Gerencia.Domain.ValueObjects.Validation.ValidationAssertion;

namespace AutoFP.Gerencia.Domain.Entities
{
    public class Marca
    {
        #region Constructors and Properties
        protected Marca() { }

        public Marca(int marcaId)
        {
            Initialize();
            ValidateId(marcaId);
        }

        public Marca(int marcaId, string marca, bool destacar, int[] categoriasSelecionadasIds)
        {
            Initialize();
            ValidateId(marcaId);
            Validate(marca, destacar, categoriasSelecionadasIds);
        }

        public Marca(int marcaId, string descricao)
        {
            Initialize();
            ValidateId(marcaId);
            ValidateDescricao(descricao);
        }

        public Marca(string descricao, bool destacar, int[] categoriasSelecionadasIds)
        {
            Initialize();
            Validate(descricao, destacar, categoriasSelecionadasIds);
        }

        public int MarcaId { get; private set; }

        public string Descricao { get; private set; }

        public bool Destacar { get; private set; }

        public int[] CategoriasPecasIds { get; set; }

        public virtual ICollection<CategoriaPeca> CategoriaPecas { get; set; }

        public virtual ICollection<Peca> Pecas { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public bool IsValid => ValidationResult.IsValid;
        #endregion

        #region Methods
        private void ValidateId(int marcaId)
        {
            if (AssertionConcern.AssertArgumentGreater(marcaId, 0, ValidationResult, MessagesDomain.InvalidMarkToCarCodeGreaterThanZero))
                MarcaId = marcaId;
        }

        private void Validate(string descricao, bool destacar, int[] categoriasSelecionadasIds)
        {
            ValidateDescricao(descricao);

            if (AssertionConcern.AssertArgumentNotEmptyAndGreaterZero(categoriasSelecionadasIds, ValidationResult, MessagesDomain.CategoriesPieceSelectedInvalid))
                CategoriasPecasIds = categoriasSelecionadasIds;

            Destacar = destacar;
        }

        private void ValidateDescricao(string marca)
        {
            if (AssertionConcern.AssertArgumentLength(marca, 2, 50, ValidationResult, MessagesDomain.MarkInvalidCaractere))
                Descricao = marca;
        }

        private void Initialize()
        {
            ValidationResult = new ValidationResult();
            CategoriaPecas = new List<CategoriaPeca>();
        }
        #endregion
    }
}