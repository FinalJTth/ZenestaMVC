using Microsoft.AspNetCore.Mvc;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ZenestaMVC.Models
{
    public class UserLoginForm
    {
        [Required(ErrorMessage = "Please fill in the username or email")]
        [DisplayName("Username or Email")]
        [Remote(action: "VerifyLoginUsername", controller: "User")]
        public string UserId { get; set; } = "";

        [Required(ErrorMessage = "Please fill in the password")]
        [DisplayName("Password")]
        public string Password { get; set; } = "";
    }
}
