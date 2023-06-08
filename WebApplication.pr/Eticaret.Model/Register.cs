
using Eticaret.Model.Enums;
using System.ComponentModel;

namespace Eticaret.Model
{
    public class Register
    {

        [DisplayName("İsim")]
        public string Firstname { get; set; } = "";

        [DisplayName("Soy İsim")]
        public string Lastname { get; set; } = "";
        [DisplayName("E-posta Adresi")]
        public string Email { get; set; } = "";
        [DisplayName("Şifre")]
        public string Password { get; set; } = "";
        [DisplayName("Doğum Tarihi")]
        public DateTime Birthday { get; set; }
        
        public Gender Gender { get; set; }
        [DisplayName("Medeni Hal")]
        public MaritalStatus MaritalStatus { get; set; }

    }
}
