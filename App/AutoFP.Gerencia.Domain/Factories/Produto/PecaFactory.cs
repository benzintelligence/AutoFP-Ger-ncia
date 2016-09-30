using AutoFP.Gerencia.Domain.Entities.Produto;
using AutoFP.Gerencia.Domain.Interface.Factories.Produto;

namespace AutoFP.Gerencia.Domain.Factories.Produto
{
    public class PecaFactory : IPecaFactory
    {
        public Peca CreateInstance(string codigoDistribuidor, string nome, string descricao, string medida, decimal precoDe, decimal precoPara, int status, bool original, int? paralelaLinhaNumero, bool importada, int marcaId, int categoriaPecaId, PosicaoPeca posicionamento)
        {
            var peca = new Peca(codigoDistribuidor, nome, descricao, medida, precoDe, precoPara, status, original, paralelaLinhaNumero, importada, marcaId, categoriaPecaId);

            if (!posicionamento.IsValid)
            {
                peca.ValidationResult.AddError(posicionamento.ValidationResult);
                return peca;
            }

            peca.PosicaoPeca = posicionamento;
            return peca;
        }
    }
}