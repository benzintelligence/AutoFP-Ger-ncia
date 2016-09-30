using System.Collections.Generic;

namespace AutoFP.Gerencia.MVC.UI.ViewModel.Pedido
{
    public class NewPedidoViewModel
    {
        public int ClienteId { get; set; }

        public bool IsPessoaFisica { get; set; }


        public IEnumerable<NewProdutoViewModel> ProdutoViewModels { get; set; }
    }
}