using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using AutoFP.Gerencia.Domain.Entities;

namespace AutoFP.Gerencia.Infra.Data.Mappings
{
    public class CategoriaPecaMap : EntityTypeConfiguration<CategoriaPeca>
    {
        public CategoriaPecaMap()
        {
            // Primary Key
            HasKey(t => t.CategoriaPecaId);

            Property(x => x.CategoriaPecaId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // Properties
            Property(t => t.Categoria)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            ToTable("CategoriaPeca");
            Property(t => t.CategoriaPecaId).HasColumnName("CategoriaPecaId");
            Property(t => t.Categoria).HasColumnName("Descricao");

            // Relationships
            HasMany(t => t.Marcas)
                .WithMany(t => t.CategoriaPecas)
                .Map(m =>
                    {
                        m.ToTable("MarcaCategoriaPeca");
                        m.MapLeftKey("CategoriaPecaId");
                        m.MapRightKey("MarcaId");
                    });

            Ignore(x => x.ValidationResult);
        }
    }
}