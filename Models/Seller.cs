using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Laboratoire3_Guitare.Models
{
    public class Seller
    {
        public int Id { get; set; }

        [DisplayName("Nom")]
        [Required(ErrorMessage = "Obligatoire")]
        public string Name { get; set; }


        [DisplayName("Courriel")]// Model state c quoi &&& ajouter style dans les elem && bootbox
        [Required(ErrorMessage = "Obligatoire")] // est-ce que checker si courriel deja existant (verif)
        [RegularExpression(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-‌​]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$",
           ErrorMessage = "Entrez un courriel syntaxiquement valide.")] 

        public string Email { get; set; }

        [DisplayName("Téléphone")]
        [Required(ErrorMessage = "Obligatoire")]
        public string Phone { get; set; }
    }
}