using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eticaret.Model
{
    [Table("Kullanici")]
    public class Login
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("E-posta"), Column(TypeName = "nvarchar(100)")]
        public string Email { get; set; } = string.Empty;

        [DisplayName("Şifre"), Column(TypeName = "nvarchar(256)")]
        public string Password { get; set; } = string.Empty;
    }
}
