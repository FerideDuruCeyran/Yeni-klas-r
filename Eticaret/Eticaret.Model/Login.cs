using System.ComponentModel;

namespace Eticaret.Model
{
    public class Login
    {
        [DisplayName("E-posta")]
        public string Email { get; set; } = string.Empty;

        [DisplayName("Şifre")]
        public string Password { get; set; } = string.Empty;
    }
}
