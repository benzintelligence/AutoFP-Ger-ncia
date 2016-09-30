using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using AutoFP.Gerencia.Domain.Entities.Localizacao;

namespace AutoFP.Gerencia.Infra.Data.Mappings.Localizacao
{
    public class EnderecoMap : EntityTypeConfiguration<Endereco>
    {
        public EnderecoMap()
        {
            // Primary Key
            HasKey(t => t.EnderecoId);

            Property(x => x.EnderecoId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // Properties
            Property(t => t.Rua)
                .IsRequired()
                .HasMaxLength(150);

            Property(t => t.Numero)
                .IsRequired()
                .HasMaxLength(20);

            Property(t => t.Complemento)
                .HasMaxLength(50);

            Property(t => t.Bairro)
                .IsRequired()
                .HasMaxLength(50);

            Property(t => t.Cep)
                .IsRequired()
                .HasMaxLength(8);

            Property(t => t.Cidade)
                .IsRequired()
                .HasMaxLength(50);

            Property(t => t.Uf)
                .IsRequired()
                .HasMaxLength(2);

            Property(t => t.PontoReferencia)
                .HasMaxLength(80);

            // Table & Column Mappings
            ToTable("Endereco");
            Property(t => t.EnderecoId).HasColumnName("EnderecoId");
            Property(t => t.Titulo).HasColumnName("Titulo");
            Property(t => t.Rua).HasColumnName("Rua");
            Property(t => t.Numero).HasColumnName("Numero");
            Property(t => t.Complemento).HasColumnName("Complemento");
            Property(t => t.Bairro).HasColumnName("Bairro");
            Property(t => t.Cep).HasColumnName("Cep");
            Property(t => t.PontoReferencia).HasColumnName("PontoReferencia");
            Property(t => t.Cobranca).HasColumnName("Cobranca");
            Property(t => t.Cidade).HasColumnName("Cidade");
            Property(t => t.Uf).HasColumnName("Uf");
            Property(t => t.PessoaId).HasColumnName("PessoaId");

            // Relationships
            HasRequired(t => t.Pessoa)
                .WithMany(t => t.Enderecos)
                .HasForeignKey(d => d.PessoaId);

            Ignore(x => x.ValidationResult);
        }
    }
}