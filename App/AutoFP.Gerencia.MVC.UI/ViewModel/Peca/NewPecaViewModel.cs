using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AutoFP.Gerencia.MVC.UI.ViewModel.Peca
{
    public class NewPecaViewModel
    {
        public NewPecaViewModel()
        {
            Marcas = new List<SelectListItem>();
            CategoriasPecas = new List<SelectListItem>();
            Montadoras = new List<SelectListItem>();
        }

        // Informações básicas de peças
        [Display(Name = @"Código de distribuidor")]
        public string CodigoDistribuidor { get; set; }

        public string Nome { get; set; }

        [Display(Name = @"Descrição")]
        public string Descricao { get; set; }

        public string Medida { get; set; }

        [Display(Name = @"Preço de:")]
        public decimal PrecoDe { get; set; }

        [Display(Name = @"Preço para:")]
        public decimal PrecoPara { get; set; }

        public int Status { get; set; }

        public bool Original { get; set; }

        [Display(Name = @"Peça paralela")]
        public int? ParalelaLinhaNumero { get; set; }

        public bool Importada { get; set; }

        [Display(Name = @"Categoria de peça")]
        public int CategoriaPecaId { get; set; }

        [Display(Name = @"Marca")]
        public int MarcaId { get; set; }

        // Posicionamento da peça
        [Display(Name = @"Lado Esquerdo")]
        public bool LadoEsquerdo { get; set; }

        [Display(Name = @"Lado Direito")]
        public bool LadoDireito { get; set; }

        [Display(Name = @"Código Dianteiro")]
        public string CodigoDianteiro { get; set; }

        [Display(Name = @"Código Traseiro")]
        public string CodigoTraseiro { get; set; }

        [Display(Name = @"Esta peça possuí posicionamento?")]
        public bool PiecePositionInformation { get; set; }

        // Combo' Box'
        public ICollection<SelectListItem> Marcas { get; set; }

        public ICollection<SelectListItem> CategoriasPecas { get; set; }

        public ICollection<SelectListItem> Montadoras { get; set; }

        public ICollection<int> CarrosModelosSelectdIds { get; set; }

        [Required(ErrorMessage = @"O produto não pode ser cadastrado sem veículos vinculados")]
        public string CarrosModelosSelectedHelper { get; set; }

        [Required(ErrorMessage = @"Nenhuma foto foi selecionada para este produto")]
        public string SelectedPhotos { get; set; }
    }
}