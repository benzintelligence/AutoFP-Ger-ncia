using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AutoFP.Gerencia.MVC.UI.ViewModel.CategoriaPeca;

namespace AutoFP.Gerencia.MVC.UI.ViewModel.Marca
{
    public class DetailMarcaViewModel
    {
        [Key]
        public int MarcaId { get; set; }

        [Display(Name = @"Marca")]
        public string Descricao { get; set; }

        public bool Destacar { get; set; }

        [Display(Name = @"Categorias atendidas:")]
        public IEnumerable<ListCategoriaPecaViewModel> ListCategoryVm { get; set; }
    }
}