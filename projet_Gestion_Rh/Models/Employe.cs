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
        public string nomPrenom { get; set; }


        [Required(ErrorMessage = "Date Naissance est obligatoire")]
        public DateTime DateNaissance { get; set; }


        [Required(ErrorMessage = "le Genre est obligatoire")]
        public string genre { get; set; } = "Female";


        [Required(ErrorMessage = "le telephone est obligatoire")]
        [MinLength(8, ErrorMessage = "Le Telephone doit comporter au moins 8 caractere")]
        public string Telephone { get; set; }


        [Required(ErrorMessage = "le adresse est obligatoire")]
        [MinLength(8, ErrorMessage = "Le addresse doit comporter au moins 8 caractere")]
        public string Adresse { get; set; }





        [Required(ErrorMessage = "le email est obligatoire")]
        [MinLength(8, ErrorMessage = "Le email doit comporter au moins 8 caractere")]
        public string email { get; set; }


        [Required(ErrorMessage = "Date Naissance est obligatoire")]
        public DateTime DateEmbauche { get; set; }

        [NotMapped]

        public IFormatFile ImageFile { get; set; }

        public int DepartementId { get; set; }
        public virtual Departement Departement { get; set; }




    }
}
