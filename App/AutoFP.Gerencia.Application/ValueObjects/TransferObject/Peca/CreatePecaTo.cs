using System.Collections.Generic;
using AutoFP.Gerencia.Application.ValueObjects.TransferObject.PosicaoPeca;

namespace AutoFP.Gerencia.Application.ValueObjects.TransferObject.Peca
{
    public class CreatePecaTo
    {
        public string CodigoDistribuidor { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public string Medida { get; set; }

        public decimal PrecoDe { get; set; }

        public decimal PrecoPara { get; set; }

        public int Status { get; set; }

        public bool Original { get; set; }

        public int? ParalelaLinhaNumero { get; set; }

        public bool Importada { get; set; }

        public int MarcaId { get; set; }

        public int CategoriaPecaId { get; set; }

        public CreatePosicaoPecaTo Posicao { get; set; }

        public IDictionary<string, int> Marcas { get; set; }

        public IDictionary<string, int> CategoriasPecas { get; set; }

        public IDictionary<string, int> Montadoras { get; set; }
    }
}