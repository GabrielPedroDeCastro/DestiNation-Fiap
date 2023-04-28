using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DestiNation.Models
{
    [Table("PASSPORT")]
    public class PassportModel
    {
        [Key]
        [Column("PASSPORTID")]
        public int PassportId { get; set; }

        [Column("PASSPORTNAME")]
        [Required(ErrorMessage = "The passport`s country name is required!")]
        [StringLength(60)]
        public string PassportName { get; set; }

        [Column("GRADE")]
        [Required(ErrorMessage = "The passport grade is required!")]
        [StringLength(60)]
        public string PassportGrade { get; set; }

        public PassportModel()
        {
            
        }

        public PassportModel(int passportId, string passportName)
        {
            PassportId = passportId;
            PassportName = passportName;
        }

    }
}
