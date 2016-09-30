using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using AutoFP.Gerencia.Domain.Entities;

namespace AutoFP.Gerencia.Infra.Data.Mappings
{
    public class EmailMap : EntityTypeConfiguration<Email>
    {
        public EmailMap()
        {
            // Primary Key
            HasKey(t => t.EmailId);

            Property(x => x.EmailId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Properties
            Property(t => t.Descricao)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            ToTable("Email");
            Property(t => t.EmailId).HasColumnName("EmailId");
            Property(t => t.Descricao).HasColumnName("Descricao");

            // Relationships
            HasRequired(t => t.Pessoa)
                .WithOptional(t => t.Email);

            Ignore(x => x.ValidationResult);
        }
    }
}