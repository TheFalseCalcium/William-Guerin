using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using Newtonsoft.Json;

//quand clicker sur image guitar afficher l'image grandeur nature sur une autre page blank
//si delete un vendeur delete toute ses guitares a vendre et afficher fenetre de confirmation
//presenter les vendeurs en ordre alphabetique 
//est-ce que price en double
namespace Laboratoire3_Guitare.Models
{
    public enum ConditionType { Neuf, Usagé }
    public enum GuitarType { Classique, Acoustique, Électrique }
    public class Guitar
    {
        public Guitar()
        {
            SellerId = -1;
            Image = GuitarImagesFolder + DefaultGuitarImage;
            AddDate = DateTime.Now;
        }  

        const string GuitarImagesFolder = @"/Images_Data/";
        const string DefaultGuitarImage = @"defaultGuitarLogo.png";

        public int Id { get; set; }
        [DisplayName("Vendeur")]
        [Required(ErrorMessage = "Veuillez sélectionner un vendeur")]
        public int SellerId { get; set; }
        [DisplayName("Fabriquant")]
        [Required(ErrorMessage = "Ce champ est requis")]
        public string Maker { get; set; }
        [DisplayName("Modèle")]
        [Required(ErrorMessage = "Ce champ est requis")]
        public string Model { get; set; }

        [Display(Name = "Image")]
        [Asset(GuitarImagesFolder, DefaultGuitarImage)]
        [Required(ErrorMessage ="Veuillez sélectionner une image")]
        public string Image { get; set; }
        [Required(ErrorMessage = "Ce champ est requis")]
        public string Description { get; set; }

        [DisplayName("Année")]
        [Required(ErrorMessage ="Champ Requis")]
        
        [Range(1800, ulong.MaxValue,ErrorMessage ="Doit être supérieur à 1800")]
        
        public int Year { get; set; }

        [JsonIgnore]
        [DisplayName("Date")]
        [Required(ErrorMessage ="Un choix est requis")]
        [DisplayFormat(DataFormatString = "{0:D}")]
        
       

        public DateTime AddDate { get; set; }
        [DisplayName("État")]
        [Required(ErrorMessage = "Un choix est requis")]

        public ConditionType? Condition { get; set; }
        [DisplayName("Type")]
        [Required(ErrorMessage = "Un choix est requis")]
        public GuitarType? GuitarType { get; set; }

        [DisplayName("Prix")]
        public int Price { get; set; }
    }

}