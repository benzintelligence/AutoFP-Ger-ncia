using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using AutoFP.Gerencia.Domain.Entities;

namespace AutoFP.Gerencia.Infra.Data.Mappings
{
    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            // Primary Key
            this.HasKey(t => t.UsuarioId);

            // Properties
            this.Property(t => t.UsuarioId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Email)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.SenhaHash)
                .IsRequired()
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("Usuario");
            this.Property(t => t.UsuarioId).HasColumnName("UsuarioId");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.EmailConfirmado).HasColumnName("EmailConfirmado");
            this.Property(t => t.SenhaHash).HasColumnName("SenhaHash");
            this.Property(t => t.IsUserManagement).HasColumnName("IsUserManagement");

            // Relationships
            this.HasRequired(t => t.Pessoa)
                .WithOptional(t => t.Usuario);

            this.Ignore(x => x.ValidationResult);
        }
    }
}