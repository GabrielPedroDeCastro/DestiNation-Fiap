using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DestiNation.Models
{
    [Table("USERTABLE")]   
    public class UserModel
    {
        [Key]
        [Column("USERID")]
        public int UserId { get; set; }

        [Column("USERNAME")]
        [Required(ErrorMessage = "The user`s name is required!")]
        [StringLength(60)]
        public string UserName { get; set; }

        [Column("USEREMAIL")]
        [Required(ErrorMessage = "The user`s e-mail is required!")]
        [StringLength(60)]
        public string Email { get; set; }

        public UserModel()
        {
            
        }

        public UserModel(int userId, string userName)
        {
            UserId = userId;
            UserName = userName;

        }

    }
}
