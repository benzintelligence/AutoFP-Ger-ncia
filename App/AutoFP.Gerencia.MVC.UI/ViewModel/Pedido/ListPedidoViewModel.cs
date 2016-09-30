using System;
using System.ComponentModel.DataAnnotations;

namespace AutoFP.Gerencia.MVC.UI.ViewModel.Pedido
{
    public class ListPedidoViewModel
    {
        [Display(Name = @"#ID")]
        public int PedidoId { get; set; }

        [Display(Name = @"Data de compra")]
        public DateTime DataCompra { get; set; }

        public string Cliente { get; set; }

        [Display(Name = @"Pedido via loja")]
        public bool PedidoPelaLoja { get; set; }

        public string Status { get; set; }

        public string Atendente { get; set; }

        [Display(Name = @"Valor total")]
        public decimal ValorTotal { get; set; }

        [Display(Name = @"Itens")]
        public int NumeroItens { get; set; }
    }
}