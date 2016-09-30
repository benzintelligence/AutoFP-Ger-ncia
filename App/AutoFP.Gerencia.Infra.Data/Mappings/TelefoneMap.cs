using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using AutoFP.Gerencia.Domain.Entities;

namespace AutoFP.Gerencia.Infra.Data.Mappings
{
    public class TelefoneMap : EntityTypeConfiguration<Telefone>
    {
        public TelefoneMap()
        {
            // Primary Key
            HasKey(t => t.TelefoneId);

            Property(x => x.TelefoneId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // Properties
            Property(t => t.Numero)
                .IsRequired()
                .HasMaxLength(11);

            // Table & Column Mappings
            ToTable("Telefone");
            Property(t => t.TelefoneId).HasColumnName("TelefoneId");
            Property(t => t.TipoTelefone).HasColumnName("TipoTelefone");
            Property(t => t.Numero).HasColumnName("Numero");
            Property(t => t.PessoaId).HasColumnName("PessoaId");

            HasRequired(t => t.Pessoa)
                .WithMany(t => t.Telefones)
                .HasForeignKey(d => d.PessoaId);

            Ignore(x => x.ValidationResult);
        }
    }
}