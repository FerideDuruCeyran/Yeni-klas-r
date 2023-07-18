using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Eticaret.Model
{
    public class Login
    {
        [Key]
        public int Id { get; set; } 
        [DisplayName("E-posta")]
        public string Email { get; set; } = string.Empty;

        [DisplayName("Şifre")]
        public string Password { get; set; } = string.Empty;
    }
}
