using AutoFP.Gerencia.Domain.Entities.Produto;

namespace AutoFP.Gerencia.Domain.Entities.Order
{
    public class ItemPedido
    {
        public int ItemPedidoId { get; set; }

        public int PedidoId { get; set; }

        public int PecaId { get; set; }

        public int Quantidade { get; set; }

        public decimal PrecoUnitario { get; set; }

        public virtual Peca Peca { get; set; }

        public virtual Pedido Pedido { get; set; }
    }
}