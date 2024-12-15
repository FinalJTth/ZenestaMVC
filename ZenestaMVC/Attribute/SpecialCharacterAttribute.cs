using System.ComponentModel.DataAnnotations;

namespace ZenestaMVC.Attribute
{
    public class SpecialCharacterAttribute : RegularExpressionAttribute
    {
        public SpecialCharacterAttribute() : base(@"^(?=.*[!@#$%^&*()_+=\[{\]};:<>|./?,-]).{1,}$") { }
    }
}
