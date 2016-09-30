using AutoFP.Gerencia.Domain.ValueObjects.Resource;
using AutoFP.Gerencia.Domain.ValueObjects.Validation;
using AutoFP.Gerencia.Domain.ValueObjects.Validation.ValidationAssertion;

namespace AutoFP.Gerencia.Domain.Entities.Produto
{
    public class PosicaoPeca
    {
        #region Constructors and Properties
        protected PosicaoPeca() { }

        public PosicaoPeca(int posicaoId)
        {
            Initialize();
            ValidateId(posicaoId);
        }

        public PosicaoPeca(bool ladoEsquerdo, bool ladoDireito, string codigoDianteiro, string codigoTraseiro)
        {
            Initialize();
            Validate(ladoEsquerdo, ladoDireito, codigoDianteiro, codigoTraseiro);
        }

        public PosicaoPeca(int posicaoId, bool ladoEsquerdo, bool ladoDireito, string codigoDianteiro, string codigoTraseiro)
        {
            Initialize();
            ValidateId(posicaoId);
            Validate(ladoEsquerdo, ladoDireito, codigoDianteiro, codigoTraseiro);
        }

        public int PosicaoId { get; private set; }

        public bool LadoEsquerdo { get; private set; }

        public bool LadoDireito { get; private set; }

        public string CodigoDianteiro { get; private set; }

        public string CodigoTraseiro { get; private set; }

        public virtual Peca Peca { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public bool IsValid => ValidationResult.IsValid;
        #endregion

        #region Methods
        private void Validate(bool ladoEsquerdo, bool ladoDireito, string codigoDianteiro, string codigoTraseiro)
        {
            string[] arguments = { codigoDianteiro, codigoTraseiro };

            if (AssertionConcern.AssertArgumentNotAllEmpty(arguments, ValidationResult, MessagesDomain.CodeFrontAndBackEmpty) &&
                AssertionConcern.AssertArgumentAllEmpty(arguments, ValidationResult, MessagesDomain.CodeFrontAndBackNotEmpty))
            {
                CodigoDianteiro = codigoDianteiro;
                CodigoTraseiro = codigoTraseiro;
            }

            LadoEsquerdo = ladoEsquerdo;
            LadoDireito = ladoDireito;
        }

        private void ValidateId(int posicaoId)
        {
            if (AssertionConcern.AssertArgumentGreater(posicaoId, 0, ValidationResult, MessagesDomain.InvalidPiecePositionId))
                PosicaoId = posicaoId;
        }

        private void Initialize()
        {
            ValidationResult = new ValidationResult();
        }
        #endregion
    }
}