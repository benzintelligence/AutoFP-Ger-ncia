using AutoFP.Gerencia.Domain.ValueObjects.Resource;
using AutoFP.Gerencia.Domain.ValueObjects.Validation;
using AutoFP.Gerencia.Domain.ValueObjects.Validation.ValidationAssertion;

namespace AutoFP.Gerencia.Domain.Entities.Localizacao
{
    public class Endereco
    {
        #region Construtor and Properties
        protected Endereco() { }

        public Endereco(int enderecoId)
        {
            Initialize();
            ValidateId(enderecoId);
        }

        public Endereco(string rua, string numero, string bairro, string cep, string pontoReferencia, bool enderecoCobranca, string cidade, string uf, string complemento = null, string titulo = null)
        {
            Initialize();
            Validate(rua, numero, bairro, cep, pontoReferencia, enderecoCobranca, cidade, uf, complemento, titulo);
        }

        public Endereco(int enderecoId, string rua, string numero, string bairro, string cep, string pontoReferencia, bool enderecoCobranca, string cidade, string uf, string complemento = null, string titulo = null)
        {
            Initialize();
            ValidateId(enderecoId);
            Validate(rua, numero, bairro, cep, pontoReferencia, enderecoCobranca, cidade, uf, complemento, titulo);
        }

        public int EnderecoId { get; private set; }

        public string Titulo { get; set; }

        public string Rua { get; private set; }

        public string Numero { get; private set; }

        public string Complemento { get; private set; }

        public string Bairro { get; private set; }

        public string Cep { get; private set; }

        public string PontoReferencia { get; private set; }

        public bool Cobranca { get; private set; }

        public string Cidade { get; private set; }

        public string Uf { get; private set; }

        public int PessoaId { get; set; }

        public virtual Pessoa.Pessoa Pessoa { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public bool IsValid => ValidationResult.IsValid;
        #endregion

        #region Methods
        private void Validate(string rua, string numero, string bairro, string cep, string pontoReferencia, bool enderecoCobranca, string cidade, string uf, string complemento, string titulo)
        {
            if (AssertionConcern.AssertArgumentLength(rua, 2, 150, ValidationResult, MessagesDomain.AddressStreetInvalid))
                Rua = rua;

            if (AssertionConcern.AssertArgumentLength(numero, 1, 20, ValidationResult, MessagesDomain.AddressNumberInvalid))
                Numero = numero;

            if (AssertionConcern.AssertArgumentLength(bairro, 2, 50, ValidationResult, MessagesDomain.AddressNeighborhoodInvalid))
                Bairro = bairro;

            if (DocumentAssertionConcern.AssertArgumentCep(cep, ValidationResult, MessagesDomain.AddressCEPInvalid))
                Cep = cep.Replace("-", "");

            if (string.IsNullOrEmpty(pontoReferencia) || AssertionConcern.AssertArgumentLength(pontoReferencia, 2, 50, ValidationResult, MessagesDomain.AddressPointReferenceInvalid))
                PontoReferencia = pontoReferencia;

            if (!AssertionConcern.AssertArgumentEmpty(cidade, ValidationResult, MessagesDomain.CodeCityToAddressGreaterThanZero))
                Cidade = cidade;

            if (!AssertionConcern.AssertArgumentEmpty(uf, ValidationResult, MessagesDomain.CodeCityToAddressGreaterThanZero))
                Uf = uf;

            if (string.IsNullOrEmpty(complemento) || AssertionConcern.AssertArgumentLength(complemento, 2, 50, ValidationResult, MessagesDomain.AddressComplementInvalid))
                Complemento = complemento;

            if (string.IsNullOrEmpty(titulo) || AssertionConcern.AssertArgumentLength(titulo, 2, 50, ValidationResult, MessagesDomain.AddressComplementInvalid))
                Titulo = titulo;

            Cobranca = enderecoCobranca;
        }

        private void ValidateId(int enderecoId)
        {
            if (AssertionConcern.AssertArgumentGreater(enderecoId, 0, ValidationResult, MessagesDomain.InvalidAddressId))
                EnderecoId = enderecoId;
        }

        private void Initialize()
        {
            ValidationResult = new ValidationResult();
        }
        #endregion
    }
}