namespace Eticaret.Model.Enums
{
    public enum MaritalStatus
    {
        [EnumDisplayName("Bekar")]
        Single,

        [EnumDisplayName("Evli")]
        Married,

        [EnumDisplayName("Dul")]
        Widow,

        [EnumDisplayName("Boşanmış")]
        Divorced
    }

    public class EnumDisplayName : Attribute
    {
        public string DisplayName { get; } = "";

        public EnumDisplayName(string displayName)
        {
            DisplayName = displayName;
        }
    }
}
