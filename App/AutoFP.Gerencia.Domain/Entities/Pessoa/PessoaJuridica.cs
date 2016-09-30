using AutoFP.Gerencia.Domain.ValueObjects.Resource;
using AutoFP.Gerencia.Domain.ValueObjects.Validation;
using AutoFP.Gerencia.Domain.ValueObjects.Validation.ValidationAssertion;

namespace AutoFP.Gerencia.Domain.Entities.Pessoa
{
    public class PessoaJuridica
    {
        #region Constructors and Properties
        protected PessoaJuridica() { }

        public PessoaJuridica(int pessoaJuridicaId)
        {
            Initialize();
            ValidateId(pessoaJuridicaId);
        }

        // Apenas para o FornecedorRepository!
        public PessoaJuridica(string cnpj, string razaoSocial)
        {
            Cnpj = cnpj;
            RazaoSocial = razaoSocial;
        }

        public PessoaJuridica(string cnpj, string razaoSocial, string nomeFantasia, string inscricaoMunicipal, string inscricaoEstadual, bool isento)
        {
            Initialize();
            Validate(cnpj, razaoSocial, nomeFantasia, inscricaoMunicipal, inscricaoEstadual, isento);
        }

        public PessoaJuridica(int pessoaJuridicaId, string cnpj, string razaoSocial, string nomeFantasia, string inscricaoMunicipal, string inscricaoEstadual, bool isento)
        {
            Initialize();
            ValidateId(pessoaJuridicaId);
            Validate(cnpj, razaoSocial, nomeFantasia, inscricaoMunicipal, inscricaoEstadual, isento);
        }

        public int PessoaJuridicaId { get; private set; }

        public string Cnpj { get; private set; }

        public string RazaoSocial { get; private set; }

        public string NomeFantasia { get; private set; }

        public string InscricaoMunicipal { get; private set; }

        public string InscricaoEstadual { get; private set; }

        public bool Isento { get; private set; }

        public virtual Pessoa Pessoa { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public bool IsValid => ValidationResult.IsValid;
        #endregion

        #region Methods
        public void SetInscricaoMunicipal(string inscricaoMunicipal)
        {
            InscricaoMunicipal = inscricaoMunicipal;
        }

        private void Validate(string cnpj, string razaoSocial, string nomeFantasia, string inscricaoMunicipal, string inscricaoEstadual, bool isento)
        {
            var cnpjResu = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            if (DocumentAssertionConcern.AssertArgumentCnpj(cnpj, ValidationResult, MessagesDomain.DocumentCnpjInvalid) &&
                AssertionConcern.AssertArgumentRangeNumeric(cnpjResu.Length, 14, 14, ValidationResult, MessagesDomain.DocumentCnpjInvalid))
                Cnpj = cnpjResu;

            if (!AssertionConcern.AssertArgumentEmpty(razaoSocial, ValidationResult, MessagesDomain.RazaoSocialEmpty))
                RazaoSocial = razaoSocial;

            if (!AssertionConcern.AssertArgumentEmpty(nomeFantasia, ValidationResult, MessagesDomain.NameFantasyEmpty))
                NomeFantasia = nomeFantasia;

            if (isento)
            {
                Isento = true;
                InscricaoEstadual = null;
            }
            else
            {
                Isento = false;
                InscricaoEstadual = inscricaoEstadual;
            }

            InscricaoMunicipal = inscricaoMunicipal;
        }

        private void ValidateId(int pessoaJuridicaId)
        {
            if (AssertionConcern.AssertArgumentGreater(pessoaJuridicaId, 0, ValidationResult, MessagesDomain.CodePersonJuridicalGreaterThanZero))
                PessoaJuridicaId = pessoaJuridicaId;
        }

        private void Initialize()
        {
            ValidationResult = new ValidationResult();
        }
        #endregion
    }
}