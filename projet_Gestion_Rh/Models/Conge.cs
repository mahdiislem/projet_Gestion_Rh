using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projet_Gestion_Rh.Models
{
    public class Conge
    {
        [Key]
        [Column(TypeName = "int")]
        public int CongeId { get; set; }


        [Required(ErrorMessage = "le Genre est obligatoire")]
        public string Type { get; set; }


        [Required(ErrorMessage = "La date de debut est obligatoire")]
        //[DisplayFormat(DataFormatString = "{yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateDebut { get; set; }



        [Required(ErrorMessage = "La date de debut est obligatoire")]
        //[DisplayFormat(DataFormatString = "{yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateFin { get; set; }



        [Required(ErrorMessage = "status est obligatoire")]
        [MinLength(3, ErrorMessage = "status doit comporter au moins 3 caractere")]
        public string Status { get; set; }

        [NotMapped]
        public double? Duree { get; set; }

        public int EmployeId { get; set; }
        public virtual Employe? Employe { get; set; }
    }
}
