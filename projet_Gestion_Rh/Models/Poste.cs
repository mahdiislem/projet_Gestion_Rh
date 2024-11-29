using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projet_Gestion_Rh.Models
{
    public class Poste
    {

        [Key]
        [Column(TypeName = "int")]
        public int PosteId { get; set; }



        [Required(ErrorMessage = "le titre est obligatoire")]
        [MinLength(3, ErrorMessage = "Le nom Doit comporter au moins 3 caractere")]
        public string Titre { get; set; }



        [Required(ErrorMessage = "le nom est obligatoire")]
        [MinLength(8, ErrorMessage = "Le description doir comporter au moins 8 caractere")]
        public string Description { get; set; }


        [Required(ErrorMessage = "le champs du salaire est obligatoire")]
        public int salaire { get; set; }

        public virtual ICollection<Employe> Employes { get; set; } = new List<Employe>();

    }
}
