using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using AutoFP.Gerencia.Domain.Entities.Pessoa;

namespace AutoFP.Gerencia.Infra.Data.Mappings.Pessoa
{
    public class ClienteMap : EntityTypeConfiguration<Cliente>
    {
        public ClienteMap()
        {
            // Primary Key
            HasKey(t => t.ClienteId);

            // Properties
            Property(x => x.ClienteId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            ToTable("Cliente");
            Property(t => t.ClienteId).HasColumnName("ClienteId");

            // Relationships
            HasRequired(t => t.Pessoa)
                .WithOptional(t => t.Cliente);

            Ignore(x => x.ValidationResult);
        }
    }
}