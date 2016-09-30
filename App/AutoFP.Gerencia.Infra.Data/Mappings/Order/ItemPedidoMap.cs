using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using AutoFP.Gerencia.Domain.Entities.Order;

namespace AutoFP.Gerencia.Infra.Data.Mappings.Order
{
    public class ItemPedidoMap : EntityTypeConfiguration<ItemPedido>
    {
        public ItemPedidoMap()
        {
            // Primary Key
            HasKey(t => new { t.ItemPedidoId, t.PedidoId, t.PecaId });

            // Properties
            Property(t => t.ItemPedidoId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(t => t.PedidoId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(t => t.PecaId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            ToTable("ItemPedido");
            Property(t => t.ItemPedidoId).HasColumnName("ItemPedidoId");
            Property(t => t.PedidoId).HasColumnName("PedidoId");
            Property(t => t.PecaId).HasColumnName("PecaId");
            Property(t => t.Quantidade).HasColumnName("Quantidade");
            Property(t => t.PrecoUnitario).HasColumnName("PrecoUnitario");

            // Relationships
            HasRequired(t => t.Peca)
                .WithMany(t => t.ItemPedidos)
                .HasForeignKey(d => d.PecaId);

            HasRequired(t => t.Pedido)
                .WithMany(t => t.ItemPedidos)
                .HasForeignKey(d => d.PedidoId);
        }
    }
}