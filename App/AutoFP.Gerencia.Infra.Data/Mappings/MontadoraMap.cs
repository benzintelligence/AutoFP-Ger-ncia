using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using AutoFP.Gerencia.Domain.Entities;

namespace AutoFP.Gerencia.Infra.Data.Mappings
{
    public class MontadoraMap : EntityTypeConfiguration<Montadora>
    {
        public MontadoraMap()
        {
            // Primary Key
            HasKey(t => t.MontadoraId);

            Property(x => x.MontadoraId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // Properties
            Property(t => t.Descricao)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(
                        new IndexAttribute("IX_Montadora") { IsUnique = true }));

            // Table & Column Mappings
            ToTable("Montadora");
            Property(t => t.MontadoraId).HasColumnName("MontadoraId");
            Property(t => t.Descricao).HasColumnName("Descricao");
            Property(t => t.Destacar).HasColumnName("Destacar");

            Ignore(x => x.ValidationResult);
        }
    }
}