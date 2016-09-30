using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using AutoFP.Gerencia.Domain.Entities.Pessoa;

namespace AutoFP.Gerencia.Infra.Data.Mappings.Pessoa
{
    public class PessoaFisicaMap : EntityTypeConfiguration<PessoaFisica>
    {
        public PessoaFisicaMap()
        {
            // Primary Key
            HasKey(t => t.PessoaFisicaId);

            // Properties
            Property(t => t.PessoaFisicaId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(t => t.Cpf)
                .IsRequired()
                .HasMaxLength(11)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(
                        new IndexAttribute("IX_Cpf") { IsUnique = true }));

            Property(t => t.Nome)
                .IsRequired()
                .HasMaxLength(60);

            Property(t => t.Sobrenome)
                .IsRequired()
                .HasMaxLength(60);

            // Table & Column Mappings
            ToTable("PessoaFisica");
            Property(t => t.PessoaFisicaId).HasColumnName("PessoaFisicaId");
            Property(t => t.Cpf).HasColumnName("Cpf");
            Property(t => t.Nome).HasColumnName("Nome");
            Property(t => t.Sobrenome).HasColumnName("Sobrenome");

            // Relationships
            HasRequired(t => t.Pessoa)
                .WithOptional(t => t.PessoaFisica);

            Ignore(x => x.ValidationResult);
        }
    }
}