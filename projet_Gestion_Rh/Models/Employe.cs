using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projet_Gestion_Rh.Models
{
    public class Employe
    {
        [Key]
        [Column (TypeName="int")]
        public int EmployeId { get; set; }

        [Required(ErrorMessage = "le nom est obligatoire")]
        [MinLength(3, ErrorMessage = "Le nom doir comporter au moins 3 caractere")]
        public string nomPrenom { get; set; }
        public String DateNaissance { get; set; }

        public String djjdjdj { get; set; }

    }
}
