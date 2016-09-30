using System.Collections.Generic;
using AutoFP.Gerencia.Domain.ValueObjects.DataTransferObject.Endereco;
using AutoFP.Gerencia.Domain.ValueObjects.Validation;

namespace AutoFP.Gerencia.Domain.ValueObjects.DataTransferObject.Cliente
{
    public class ClienteDTO
    {
        public ClienteDTO() { Initialize(); }

        public int clienteId { get; set; }

        #region PessoaFisica
        public string cliente { get; set; }

        public string cpf { get; set; }
        #endregion

        #region PessoaJuridica
        public string cnpj { get; set; }

        public string razaoSocial { get; set; }

        public string nomeFantasia { get; set; }

        public string inscricaoEstadual { get; set; }

        public string inscricaoMunicipal { get; set; }
        #endregion

        public IEnumerable<EnderecoDTO> Enderecos { get; set; }

        public string email { get; set; }

        public IEnumerable<TelefoneDTO> Telefones { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public bool IsValid => ValidationResult.IsValid;

        private void Initialize()
        {
            ValidationResult = new ValidationResult();
        }
    }
}