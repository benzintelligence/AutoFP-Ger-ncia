using System.Data.Entity.ModelConfiguration;

namespace AutoFP.Gerencia.Infra.Data.Mappings.Pessoa
{
    public class PessoaMap : EntityTypeConfiguration<Domain.Entities.Pessoa.Pessoa>
    {
        public PessoaMap()
        {
            // Primary Key
            HasKey(t => t.PessoaId);

            // Properties 
            // Table & Column Mappings
            ToTable("Pessoa");
            Property(t => t.PessoaId).HasColumnName("PessoaId");
            Property(t => t.TipoPessoa).HasColumnName("TipoPessoa");

            Ignore(x => x.ValidationResult);
        }
    }
}