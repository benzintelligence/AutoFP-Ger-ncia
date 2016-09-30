using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using AutoFP.Gerencia.Domain.Entities.Produto;

namespace AutoFP.Gerencia.Infra.Data.Mappings.Produto
{
    public class GaleriaMap : EntityTypeConfiguration<Galeria>
    {
        public GaleriaMap()
        {
            // Primary Key
            HasKey(t => new { t.GaleriaId, t.PecaId });

            // Properties
            Property(t => t.GaleriaId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(t => t.PecaId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(t => t.ImageLink)
                .IsRequired()
                .HasMaxLength(21);

            // Table & Column Mappings
            ToTable("Galeria");
            Property(t => t.GaleriaId).HasColumnName("GaleriaId");
            Property(t => t.PecaId).HasColumnName("PecaId");
            Property(t => t.ImageLink).HasColumnName("ImageLink");

            // Relationships
            HasRequired(t => t.Peca)
                .WithMany(t => t.Galerias)
                .HasForeignKey(d => d.PecaId);

            Ignore(x => x.ValidationResult);
        }
    }
}