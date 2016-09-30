using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using AutoFP.Gerencia.Domain.Entities.Pessoa;

namespace AutoFP.Gerencia.Infra.Data.Mappings.Pessoa
{
    public class FornecedorMap : EntityTypeConfiguration<Fornecedor>
    {
        public FornecedorMap()
        {
            // Primary Key
            this.HasKey(t => t.FornecedorId);

            // Properties
            this.Property(x => x.FornecedorId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("Fornecedor");
            this.Property(t => t.FornecedorId).HasColumnName("FornecedorId");

            // Relationships
            this.HasMany(t => t.Pecas)
                .WithMany(t => t.Fornecedores)
                .Map(m =>
                {
                    m.ToTable("PecaFornecedor");
                    m.MapLeftKey("FornecedorId");
                    m.MapRightKey("PecaId");
                });

            this.HasRequired(t => t.Pessoa)
                .WithOptional(x => x.Fornecedor);

            this.Ignore(x => x.ValidationResult);
        }
    }
}