using System;
using System.Collections.Generic;
using AutoFP.Gerencia.Domain.Entities.Pessoa;

namespace AutoFP.Gerencia.Domain.Entities.Order
{
    public class Pedido
    {
        protected Pedido() { }

        public int PedidoId { get; set; }

        public DateTime DataCompra { get; set; }

        public int Status { get; set; }

        public int ClienteId { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual ICollection<ItemPedido> ItemPedidos { get; set; }
    }
}