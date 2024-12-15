using System.ComponentModel.DataAnnotations;

namespace ZenestaMVC.Attribute
{
    public class NumberAttribute : RegularExpressionAttribute
    {
        public NumberAttribute() : base(@"^(?=.*\d).{1,}$") { }
    }
}
