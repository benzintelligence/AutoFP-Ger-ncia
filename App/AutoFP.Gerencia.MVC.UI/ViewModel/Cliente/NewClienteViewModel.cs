using System.ComponentModel.DataAnnotations;

namespace AutoFP.Gerencia.MVC.UI.ViewModel.Cliente
{
    public class NewClienteViewModel
    {
        public bool IsPessoaFisica { get; set; }

        #region PessoaFisica
        [Display(Name = @"CPF")]
        public string Cpf { get; set; }

        public string Nome { get; set; }

        public string Sobrenome { get; set; }
        #endregion

        #region PessoaJuridica
        [Display(Name = @"CNPJ")]
        public string Cnpj { get; set; }

        [Display(Name = @"Razão Social")]
        public string RazaoSocial { get; set; }

        [Display(Name = @"Nome fantasia")]
        public string NomeFantasia { get; set; }

        [Display(Name = @"Inscrição estadual")]
        public string InscricaoEstadual { get; set; }

        [Display(Name = @"Inscrição municipal")]
        public string InscricaoMunicipal { get; set; }

        public bool Isento { get; set; }
        #endregion

        #region Endereco1
        public string Logradouro { get; set; }

        [Display(Name = @"Número")]
        public string Numero { get; set; }

        public string Complemento { get; set; }

        public string Bairro { get; set; }

        [Display(Name = @"CEP")]
        public string Cep { get; set; }

        [Display(Name = @"Ponto de referência")]
        public string PontoReferencia { get; set; }

        [Display(Name = @"Utilizar este endereço para entrega?")]
        public bool IsEntrega { get; set; }

        [Display(Name = @"Cidade")]
        public string Cidade { get; set; }

        [Display(Name = @"Estado")]
        public string Estado { get; set; }
        #endregion

        #region Endereco2
        [Display(Name = @"Logradouro")]
        public string Logradouro2 { get; set; }

        [Display(Name = @"Número")]
        public string Numero2 { get; set; }

        [Display(Name = @"Complemento")]
        public string Complemento2 { get; set; }

        [Display(Name = @"Bairro")]
        public string Bairro2 { get; set; }

        [Display(Name = @"CEP")]
        public string Cep2 { get; set; }

        [Display(Name = @"Ponto de referência")]
        public string PontoReferencia2 { get; set; }

        [Display(Name = @"Cidade")]
        public string Cidade2 { get; set; }

        [Display(Name = @"Estado")]
        public string Estado2 { get; set; }
        #endregion

        #region Email
        [Display(Name = @"E-mail")]
        [Required(ErrorMessage = @"Um e-mail é necessário", AllowEmptyStrings = false)]
        [EmailAddress(ErrorMessage = @"Informe um e-mail válido")]
        public string Email { get; set; }
        #endregion

        #region Telefones
        // Telefone 1
        [Required(AllowEmptyStrings = false)]
        [Display(Name = @"DDD + Telefone")]
        public string TelefoneNumero1 { get; set; }

        [Display(Name = @"Tipo")]
        public int TipoTelefone1 { get; set; }

        // Telefone 2
        [Required(AllowEmptyStrings = false)]
        [Display(Name = @"DDD + Telefone")]
        public string TelefoneNumero2 { get; set; }

        [Display(Name = @"Tipo")]
        public int TipoTelefone2 { get; set; }
        #endregion
    }
}