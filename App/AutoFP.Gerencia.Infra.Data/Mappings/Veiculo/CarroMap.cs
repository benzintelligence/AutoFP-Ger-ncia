using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using AutoFP.Gerencia.Domain.Entities.Veiculo;

namespace AutoFP.Gerencia.Infra.Data.Mappings.Veiculo
{
    public class CarroMap : EntityTypeConfiguration<Carro>
    {
        public CarroMap()
        {
            // Primary Key
            HasKey(t => t.CarroId);

            Property(x => x.CarroId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // Properties
            Property(t => t.Nome)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            ToTable("Carro");
            Property(t => t.CarroId).HasColumnName("CarroId");
            Property(t => t.Nome).HasColumnName("Nome");
            Property(t => t.MontadoraId).HasColumnName("MontadoraId");

            // Relationships
            HasRequired(t => t.Montadora)
                .WithMany(t => t.Carros)
                .HasForeignKey(d => d.MontadoraId);

            Ignore(x => x.ValidationResult);
        }
    }
}