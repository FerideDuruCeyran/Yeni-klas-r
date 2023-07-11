using Eticaret.Model.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Eticaret.Model
{
    public class Register
    {
        [DisplayName("Ad")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ad alanı zorunludur.")]
        public string Firstname { get; set; } = string.Empty;

        [DisplayName("Soyad")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Soyad alanı zorunludur.")]
        public string Lastname { get; set; } = string.Empty;

        [DisplayName("E-posta Adresi")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "E-posta alanı zorunludur.")]
        [EmailAddress(ErrorMessage = "Hatalı e-posta kullandınız.")]
        public string Email { get; set; } = string.Empty;

        [DisplayName("Şifre")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Şifre alanı zorunludur.")]
        public string Password { get; set; } = string.Empty;

        [DisplayName("Şifre Tekrar")]
        [Compare("Password", ErrorMessage = "Girdiğiniz şifreler aynı olmalıdır.")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Şifre alanı zorunludur.")]
        public string Password2 { get; set; } = string.Empty;

        [DisplayName("Doğum Tarihi")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Doğum tarihi alanı zorunludur.")]
        public DateTime Birthday { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Cinsiyet alanı zorunludur.")]
        public Gender Gender { get; set; }

        [DisplayName("Medeni Durum")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Medeni durum alanı zorunludur.")]
        public MaritalStatus MaritalStatus { get; set; }

    }
}
