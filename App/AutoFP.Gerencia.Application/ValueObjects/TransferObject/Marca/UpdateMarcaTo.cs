using System.Collections.Generic;
using AutoFP.Gerencia.Application.ValueObjects.TransferObject.CategoriaPeca;

namespace AutoFP.Gerencia.Application.ValueObjects.TransferObject.Marca
{
    public class UpdateMarcaTo
    {
        public int MarcaId { get; set; }

        public string Descricao { get; set; }

        public bool Destacar { get; set; }

        public int[] CategoriasSelecionadasIds { get; set; }

        public virtual IEnumerable<SelectListCategoriaPecaTo> SelectListCategoriaPecasTo { get; set; }
    }
}