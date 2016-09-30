using System.Collections.Generic;
using AutoFP.Gerencia.Domain.Entities.Order;
using AutoFP.Gerencia.Domain.Entities.Pessoa;
using AutoFP.Gerencia.Domain.Entities.Veiculo;
using AutoFP.Gerencia.Domain.ValueObjects.Enums;
using AutoFP.Gerencia.Domain.ValueObjects.Resource;
using AutoFP.Gerencia.Domain.ValueObjects.Validation;
using AutoFP.Gerencia.Domain.ValueObjects.Validation.ValidationAssertion;

namespace AutoFP.Gerencia.Domain.Entities.Produto
{
    public class Peca
    {
        #region Constructors and Properties
        protected Peca() { }

        public Peca(int pecaId)
        {
            Initialize();
            ValidateId(pecaId);
        }

        public Peca(string codigoDistribuidor, string nome, string descricao, string medida, decimal precoDe, decimal precoPara, int status, bool original, int? paralelaLinhaNumero, bool importada, int marcaId, int categoriaPecaId)
        {
            Initialize();
            Validate(codigoDistribuidor, nome, descricao, medida, precoDe, precoPara, status, original, paralelaLinhaNumero, importada, marcaId, categoriaPecaId);
        }

        public Peca(int pecaId, string codigoDistribuidor, string nome, string descricao, string medida, decimal precoDe, decimal precoPara, int status, bool original, int? paralelaLinhaNumero, bool importada, int marcaId, int categoriaPecaId)
        {
            Initialize();
            ValidateId(pecaId);
            Validate(codigoDistribuidor, nome, descricao, medida, precoDe, precoPara, status, original, paralelaLinhaNumero, importada, marcaId, categoriaPecaId);
        }

        public int PecaId { get; private set; }

        public int CategoriaPecaId { get; private set; }

        public string CodigoDistribuidor { get; private set; }

        public string Nome { get; private set; }

        public string Descricao { get; private set; }

        public string Medida { get; private set; }

        public decimal PrecoDe { get; private set; }

        public decimal PrecoPara { get; private set; }

        public int Status { get; private set; } // Nova ou remanufaturada (remanufaturada quando for original)

        public bool Original { get; private set; }

        public int? ParalelaLinhaNumero { get; private set; }

        public bool Importada { get; private set; }

        public int MarcaId { get; private set; }

        public virtual CategoriaPeca CategoriaPeca { get; set; }

        public virtual Marca Marca { get; set; }

        public virtual PosicaoPeca PosicaoPeca { get; set; }

        public virtual ICollection<Galeria> Galerias { get; set; }

        public virtual ICollection<AnoModeloCarro> AnoModeloCarros { get; set; }

        public virtual ICollection<ItemPedido> ItemPedidos { get; set; }

        public virtual ICollection<Fornecedor> Fornecedores { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public bool IsValid => ValidationResult.IsValid;
        #endregion

        #region Methods
        public void ChangeParalelaLinhaPeca(int paralelaLinhaPeca)
        {
            if (AssertionConcern.AssertArgumentGreater(paralelaLinhaPeca, 0, ValidationResult, MessagesDomain.InvalidCodeLinePecaGreaterThanZero) ||
                !AssertionConcern.AssertArgumentIsTrue(Original, ValidationResult, MessagesDomain.ProductOriginalNotLine))
                ParalelaLinhaNumero = paralelaLinhaPeca;
        }

        private void Validate(string codigoDistribuidor, string nome, string descricao, string medida, decimal precoDe, decimal precoPara, int status, bool original, int? paralelaLinhaNumero, bool importada, int marcaId, int categoriaPecaId)
        {
            if (!AssertionConcern.AssertArgumentEmpty(codigoDistribuidor, ValidationResult, MessagesDomain.ProductCodeDistributor))
                CodigoDistribuidor = codigoDistribuidor;

            if (!AssertionConcern.AssertArgumentEmpty(nome, ValidationResult, MessagesDomain.ProductNameInvalid))
                Nome = nome;

            if (!AssertionConcern.AssertArgumentEmpty(descricao, ValidationResult, MessagesDomain.ProductDescriptionInvalid))
                Descricao = descricao;

            if (!AssertionConcern.AssertArgumentEmpty(medida, ValidationResult, MessagesDomain.ProductMeasureInvalid))
                Medida = medida;

            if (AssertionConcern.AssertArgumentGreater(precoDe, 0, ValidationResult, MessagesDomain.ProductPriceInvalid))
                PrecoDe = precoDe;

            if (AssertionConcern.AssertArgumentGreater(precoPara, 0, ValidationResult, MessagesDomain.ProductPriceInvalid))
                PrecoPara = precoPara;

            if (AssertionConcern.AssertArgumentRangeNumeric(status, (int)PecaStatus.Nova, (int)PecaStatus.Recondicionada, ValidationResult, MessagesDomain.CodeInvalidStatusToPiece))
                Status = status;

            if (AssertionConcern.AssertArgumentGreater(marcaId, 0, ValidationResult, MessagesDomain.CodeProductMarkGreaterThanZero))
                MarcaId = marcaId;

            if (AssertionConcern.AssertArgumentGreater(categoriaPecaId, 0, ValidationResult, MessagesDomain.CodeProductMarkGreaterThanZero))
                CategoriaPecaId = categoriaPecaId;

            if (original)
            {
                Original = true;
                ParalelaLinhaNumero = null;
            }
            else
            {
                if (AssertionConcern.AssertArgumentNotNull(paralelaLinhaNumero, ValidationResult, MessagesDomain.ParallelLineNumberNotInformation) &&
                    AssertionConcern.AssertArgumentRangeNumeric( (int) paralelaLinhaNumero, (int) PecaParalela.PrimeiraLinha, (int) PecaParalela.TerceiraLinha, ValidationResult, MessagesDomain.ParallelLineNumberInvalid))
                    ParalelaLinhaNumero = paralelaLinhaNumero;

                Original = false;
            }

            Importada = importada;
        }

        private void ValidateId(int pecaId)
        {
            if (AssertionConcern.AssertArgumentGreater(pecaId, 0, ValidationResult, MessagesDomain.InvalidPieceId))
                PecaId = pecaId;
        }

        private void Initialize()
        {
            ValidationResult = new ValidationResult();
        }
        #endregion
    }
}