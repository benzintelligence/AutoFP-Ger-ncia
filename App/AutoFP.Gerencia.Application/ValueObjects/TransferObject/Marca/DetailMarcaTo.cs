using System.Collections.Generic;
using AutoFP.Gerencia.Application.ValueObjects.TransferObject.CategoriaPeca;

namespace AutoFP.Gerencia.Application.ValueObjects.TransferObject.Marca
{
    public class DetailMarcaTo
    {
        public int MarcaId { get; set; }

        public string Descricao { get; set; }

        public bool Destacar { get; set; }

        public virtual IEnumerable<ListCategoriaPecaTo> ListCategoriaPecasTo { get; set; }
    }
}