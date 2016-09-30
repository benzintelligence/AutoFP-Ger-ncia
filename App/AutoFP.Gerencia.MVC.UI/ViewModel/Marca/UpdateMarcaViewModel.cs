using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using AutoFP.Gerencia.MVC.UI.Resource;

namespace AutoFP.Gerencia.MVC.UI.ViewModel.Marca
{
    public class UpdateMarcaViewModel
    {
        [Key]
        public int MarcaId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessageResourceType = typeof(MessagesViewModel), ErrorMessageResourceName = "MarkInvalidCaractere")]
        [Display(Name = @"Marca")]
        public string Descricao { get; set; }

        public bool Destacar { get; set; }

        public MultiSelectList CategoriasPecas { get; set; }

        [Required]
        [Display(Name = @"Categorias de peças")]
        public int[] CategoriasIdsSelecionadas { get; set; }
    }
}