using System.Collections.Generic;
using AutoFP.Gerencia.Domain.Entities;

namespace AutoFP.Gerencia.Domain.ValueObjects.DataTransferObject
{
    public class MarcaDTO
    {
        public MarcaDTO()
        {
            CategoriaPecas = new List<CategoriaPeca>();
        }

        public int MarcaId { get; set; }

        public string Marca { get; set; }

        public bool Destacar { get; set; }

        public ICollection<CategoriaPeca> CategoriaPecas { get; set; }
    }
}