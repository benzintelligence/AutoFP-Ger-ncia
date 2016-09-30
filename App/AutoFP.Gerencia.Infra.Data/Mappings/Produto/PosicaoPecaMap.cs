using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using AutoFP.Gerencia.Domain.Entities.Produto;

namespace AutoFP.Gerencia.Infra.Data.Mappings.Produto
{
    public class PosicaoPecaMap : EntityTypeConfiguration<PosicaoPeca>
    {
        public PosicaoPecaMap()
        {
            // Primary Key
            HasKey(t => t.PosicaoId);

            // Properties
            Property(t => t.PosicaoId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(t => t.CodigoDianteiro)
                .HasMaxLength(20);

            Property(t => t.CodigoTraseiro)
                .HasMaxLength(20);

            // Table & Column Mappings
            ToTable("PosicaoPeca");
            Property(t => t.PosicaoId).HasColumnName("PosicaoId");
            Property(t => t.LadoEsquerdo).HasColumnName("LadoEsquerdo");
            Property(t => t.LadoDireito).HasColumnName("LadoDireito");
            Property(t => t.CodigoDianteiro).HasColumnName("CodigoDianteiro");
            Property(t => t.CodigoTraseiro).HasColumnName("CodigoTraseiro");

            // Relationships
            HasRequired(t => t.Peca)
                .WithOptional(t => t.PosicaoPeca);

            Ignore(x => x.ValidationResult);
        }
    }
}