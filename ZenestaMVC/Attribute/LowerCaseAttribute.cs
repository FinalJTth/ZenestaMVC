using System.ComponentModel.DataAnnotations;

namespace ZenestaMVC.Attribute
{
    public class LowerCaseAttribute : RegularExpressionAttribute
    {
        public LowerCaseAttribute() : base(@"^(?=.*[a-z]).{1,}$") { }
    }
}
