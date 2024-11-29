using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projet_Gestion_Rh.Models
{
    public class Employe
    {
        [Key]
        [Column(TypeName = "int")]
        public int EmployeId { get; set; }

        [Required(ErrorMessage = "le nom est obligatoire")]
        [MinLength(3, ErrorMessage = "Le nom doir comporter au moins 3 caractere")]
        public string NomPrenom { get; set; }


        [Required(ErrorMessage = "La date de naissance est obligatoire")]
        //[DisplayFormat(DataFormatString = "{yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateNaissance { get; set; }


        [Required(ErrorMessage = "le Genre est obligatoire")]
        public string Genre { get; set; } 


        [Required(ErrorMessage = "le telephone est obligatoire")]
        [MinLength(8, ErrorMessage = "Le Telephone doit comporter au moins 8 caractere")]
        public string Telephone { get; set; }


        [Required(ErrorMessage = "le adresse est obligatoire")]
        [MinLength(8, ErrorMessage = "Le addresse doit comporter au moins 8 caractere")]
        public string Adresse { get; set; }





        [Required(ErrorMessage = "le email est obligatoire")]
        [MinLength(8, ErrorMessage = "Le email doit comporter au moins 8 caractere")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Date Naissance est obligatoire")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateEmbauche { get; set; }

        
        //[Display(Name = "choisir photo")]
        //[Required]
        //public IFormatFile? ImageFile { get; set; }
        // Ajoutez également la propriété pour stocker le chemin de l'image sur le serveur
        // public string ImagePath { get; set; }
        public string? Image { get; set; }

        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile? imageFile { get; set; }

        public int DepartementId { get; set; }
        public virtual Departement? Departement { get; set; }

        public int? PosteId { get; set; }
        public virtual Poste? Poste { get; set; }
        public virtual ICollection<Conge> Conges { get; set; } = new List<Conge>();


    }
}
