using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;

namespace ZenestaMVC.Models.Entity
{
    [Index(nameof(Username), nameof(Email), IsUnique = true)]
    public class User
    {
        [Key]
        public int Id { get; set; }

        [StringLength(24)]
        [Required]
        public string Username { get; set; } = "";

        [Required]
        [DataType(DataType.Password)]
        [StringLength(72)]
        public string Password { get; set; } = "";

        [StringLength(320)]
        [Required]
        [EmailAddress]
        public string Email { get; set; } = "";

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public int Age { get; set; }

        // Navigation property section
        public ICollection<PredictionBatch>? PredictionBatches { get; set; }

        public User(string username, string password, string email, DateTime dateOfBirth, int age)
        {
            Username = username;
            Password = password;
            Email = email;
            DateOfBirth = dateOfBirth;
            Age = age;
        }
    }
}
