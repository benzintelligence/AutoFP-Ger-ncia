using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using AutoFP.Gerencia.Domain.Entities.Pessoa;

namespace AutoFP.Gerencia.Infra.Data.Mappings.Pessoa
{
    public class PessoaJuridicaMap : EntityTypeConfiguration<PessoaJuridica>
    {
        public PessoaJuridicaMap()
        {
            // Primary Key
            HasKey(t => t.PessoaJuridicaId);
            Property(t => t.PessoaJuridicaId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Properties
            Property(t => t.Cnpj)
                .IsRequired()
                .HasMaxLength(14)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(
                        new IndexAttribute("IX_Cnpj") { IsUnique = true }));

            Property(t => t.RazaoSocial)
                .IsRequired()
                .HasMaxLength(150);

            Property(t => t.NomeFantasia)
                .IsRequired()
                .HasMaxLength(150);

            Property(t => t.InscricaoMunicipal)
                .IsOptional()
                .HasMaxLength(30);

            Property(t => t.InscricaoEstadual)
                .IsOptional()
                .HasMaxLength(20)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(
                        new IndexAttribute("IX_InscricaoEstadual") { IsUnique = true }));

            // Table & Column Mappings
            ToTable("PessoaJuridica");
            Property(t => t.PessoaJuridicaId).HasColumnName("PessoaJuridicaId");
            Property(t => t.Cnpj).HasColumnName("Cnpj");
            Property(t => t.RazaoSocial).HasColumnName("RazaoSocial");
            Property(t => t.NomeFantasia).HasColumnName("NomeFantasia");
            Property(t => t.InscricaoMunicipal).HasColumnName("InscricaoMunicipal");
            Property(t => t.InscricaoEstadual).HasColumnName("InscricaoEstadual");
            Property(t => t.Isento).HasColumnName("Isento");

            // Relationships
            HasRequired(t => t.Pessoa)
                .WithOptional(t => t.PessoaJuridica);

            Ignore(x => x.ValidationResult);
        }
    }
}