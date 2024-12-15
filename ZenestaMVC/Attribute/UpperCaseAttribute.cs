using System.ComponentModel.DataAnnotations;

namespace ZenestaMVC.Attribute
{
    public class UpperCaseAttribute : RegularExpressionAttribute
    {
        public UpperCaseAttribute() : base(@"^(?=.*[A-Z]).{1,}$") { }
    }
}
