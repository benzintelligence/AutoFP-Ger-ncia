using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using AutoFP.Gerencia.MVC.UI.Resource;

namespace AutoFP.Gerencia.MVC.UI.ViewModel.Montadora
{
    public class NewMontadoraViewModel
    {
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessageResourceType = typeof(MessagesViewModel), ErrorMessageResourceName = "InvalidManufacturerDescription")]
        [DisplayName(@"Montadora")]
        public string Montadora { get; set; }

        public bool Destacar { get; set; }
    }
}