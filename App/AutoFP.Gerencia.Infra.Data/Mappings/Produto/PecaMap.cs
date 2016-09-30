using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using AutoFP.Gerencia.Domain.Entities.Produto;

namespace AutoFP.Gerencia.Infra.Data.Mappings.Produto
{
    public class PecaMap : EntityTypeConfiguration<Peca>
    {
        public PecaMap()
        {
            // Primary Key
            HasKey(t => t.PecaId);

            Property(x => x.PecaId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // Properties
            Property(t => t.CodigoDistribuidor)
                .IsRequired()
                .HasMaxLength(20);

            Property(t => t.Nome)
                .IsRequired()
                .HasMaxLength(50);

            Property(t => t.Descricao)
                .HasColumnType("text");

            Property(t => t.Medida)
                .IsRequired()
                .HasMaxLength(20);

            // Table & Column Mappings
            ToTable("Peca");
            Property(t => t.PecaId).HasColumnName("PecaId");
            Property(t => t.CodigoDistribuidor).HasColumnName("CodigoDistribuidor");
            Property(t => t.Nome).HasColumnName("Nome");
            Property(t => t.Descricao).HasColumnName("Descricao");
            Property(t => t.Medida).HasColumnName("Medida");
            Property(t => t.PrecoDe).HasColumnName("PrecoDe");
            Property(t => t.PrecoPara).HasColumnName("PrecoPara");
            Property(t => t.Status).HasColumnName("Status");
            Property(t => t.Original).HasColumnName("Original");
            Property(t => t.ParalelaLinhaNumero).HasColumnName("ParalelaLinhaNumero");
            Property(t => t.Importada).HasColumnName("Importada");
            Property(t => t.MarcaId).HasColumnName("MarcaId");
            Property(t => t.CategoriaPecaId).HasColumnName("CategoriaPecaId");

            // Relationships
            HasRequired(t => t.CategoriaPeca)
                .WithMany(t => t.Pecas)
                .HasForeignKey(d => d.CategoriaPecaId);

            HasRequired(t => t.Marca)
                .WithMany(t => t.Pecas)
                .HasForeignKey(d => d.MarcaId);

            Ignore(x => x.ValidationResult);
        }
    }
}