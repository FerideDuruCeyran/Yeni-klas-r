

using System.Runtime.CompilerServices;

namespace Eticaret.Model.Enums
{
    public enum MaritalStatus
    {
        [EnumDisplayName("Bekar")]
        Single,
        [EnumDisplayName("Evli")]
        Married,
        [EnumDisplayName("")]
        Widow,
        [EnumDisplayName("Boşanmış")]
        Divorced,
    }
    public class EnumDisplayName: Attribute 
    {
        public string DisplayName { get; set; } = "";
        public EnumDisplayName(string displayName)
        {
            DisplayName = displayName;
        }
       
    }
}
