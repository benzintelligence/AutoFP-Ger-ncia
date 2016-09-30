using System.Data.Entity.ModelConfiguration;
using AutoFP.Gerencia.Domain.Entities.Veiculo;

namespace AutoFP.Gerencia.Infra.Data.Mappings.Veiculo
{
    public class AnoModeloCarroMap : EntityTypeConfiguration<AnoModeloCarro>
    {
        public AnoModeloCarroMap()
        {
            // Primary Key
            HasKey(t => t.AnoModeloCarroId);

            // Properties
            // Table & Column Mappings
            ToTable("AnoModeloCarro");
            Property(t => t.AnoModeloCarroId).HasColumnName("AnoModeloCarroId");
            Property(t => t.CarroId).HasColumnName("CarroId");
            Property(t => t.Ano).HasColumnName("Ano");

            // Relationships
            HasMany(t => t.Pecas)
                .WithMany(t => t.AnoModeloCarros)
                .Map(m =>
                {
                    m.ToTable("CarroPecaAno");
                    m.MapLeftKey("CarroModeloId");
                    m.MapRightKey("PecaId");
                });

            HasRequired(t => t.Carro)
                .WithMany(t => t.AnoModeloCarros)
                .HasForeignKey(d => d.CarroId);

            Ignore(x => x.ValidationResult);
        }
    }
}