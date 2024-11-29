using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace projet_Gestion_Rh.Models
{
    public class Departement
    {

        [Key]
        [Column(TypeName = "int")]
        public int DepartementId { get; set; }

        [Required(ErrorMessage = "le nom du departement est obligatoire")]
        [MinLength(3, ErrorMessage = "Le nom doir comporter au moins 3 caractere")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "le nom est obligatoire")]
        [MinLength(8, ErrorMessage = "Le description doir comporter au moins 8 caractere")]
        public string Description { get; set; }


        [Required(ErrorMessage = "le nom du responsable est obligatoire")]
        [MinLength(3, ErrorMessage = "Le nom doir comporter au moins 3 caractere")]
        public string NomResponsable { get; set; }


        public virtual ICollection<Employe> Employes { get; set; } = new List<Employe>();



    }
}
