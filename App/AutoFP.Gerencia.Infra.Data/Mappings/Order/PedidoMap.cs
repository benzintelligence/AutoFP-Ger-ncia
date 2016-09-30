using System.Data.Entity.ModelConfiguration;
using AutoFP.Gerencia.Domain.Entities.Order;

namespace AutoFP.Gerencia.Infra.Data.Mappings.Order
{
    public class PedidoMap : EntityTypeConfiguration<Pedido>
    {
        public PedidoMap()
        {
            // Primary Key
            HasKey(t => t.PedidoId);

            // Properties
            // Table & Column Mappings
            ToTable("Pedido");
            Property(t => t.PedidoId).HasColumnName("PedidoId");
            Property(t => t.DataCompra).HasColumnName("DataCompra");
            Property(t => t.Status).HasColumnName("Status");
            Property(t => t.ClienteId).HasColumnName("ClienteId");

            // Relationships
            HasRequired(t => t.Cliente)
                .WithMany(t => t.Pedidos)
                .HasForeignKey(d => d.ClienteId);
        }
    }
}