using System.Collections.Generic;

namespace AutoFP.Gerencia.Domain.ValueObjects.DataTransferObject
{
    public class PecaDTO
    {
        public PecaDTO()
        {
            Marcas = new Dictionary<string, int>();
            CategoriasPecas = new Dictionary<string, int>();
            Montadoras = new Dictionary<string, int>();
        }

        public IDictionary<string, int> Marcas { get; set; }

        public IDictionary<string, int> CategoriasPecas { get; set; }

        public IDictionary<string, int> Montadoras { get; set; }
    }
}