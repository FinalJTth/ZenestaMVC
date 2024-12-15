using Microsoft.AspNetCore.Mvc;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ZenestaMVC.Models
{
    public class UserRegisterForm
    {
        [Required]
        [StringLength(24)]
        [Remote(action: "VerifyRegisterUsername", controller: "User")]
        [DisplayName("Username")]
        public string Username { get; set; } = "";

        [Required]
        [DataType(DataType.Password)]
        [StringLength(32, ErrorMessage = "Must be at most 32 characters")]
        [MinLength(7, ErrorMessage = "Must be at least 8 characters")]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{0,}$", ErrorMessage = "Must contain at least one of lower, upper, number character")]
        [DisplayName("Password")]
        public string Password { get; set; } = "";

        [StringLength(320)]
        [Required]
        [EmailAddress]
        [Remote(action: "VerifyRegisterEmail", controller: "User")]
        [DisplayName("Email")]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "Required")]
        [DisplayName("Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Required")]
        [DisplayName("Age")]
        public int Age { get; set; }
    }
}
