using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using AutoFP.Gerencia.Domain.Entities;

namespace AutoFP.Gerencia.Infra.Data.Mappings
{
    public class MarcaMap : EntityTypeConfiguration<Marca>
    {
        public MarcaMap()
        {
            // Primary Key
            HasKey(t => t.MarcaId);

            Property(x => x.MarcaId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // Properties
            Property(t => t.Descricao)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(
                        new IndexAttribute("IX_Marca") { IsUnique = true }));

            // Table & Column Mappings
            ToTable("Marca");
            Property(t => t.MarcaId).HasColumnName("MarcaId");
            Property(t => t.Descricao).HasColumnName("Descricao");
            Property(t => t.Destacar).HasColumnName("Destacar");

            Ignore(x => x.CategoriasPecasIds);
            Ignore(x => x.ValidationResult);
        }
    }
}