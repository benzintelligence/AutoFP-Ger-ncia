namespace AutoFP.Gerencia.Application.Interface
{
    public interface IPedidoAppService
    {
        void ObterDetalhesDoPedido(int pedidoId);

        void NovoPedido();

        void EnviarParaTransportadora();

        void CancelarPedido();
    }
}