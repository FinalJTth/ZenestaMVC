using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZenestaMVC.Models.Entity
{
    public class PredictionBatch
    {
        [Key]
        public int Id { get; set; }

        [StringLength(64)]
        public string Name { get; set; } = null!;

        public DateTime DatePublished { get; set; }

        [ForeignKey(nameof(User))]
        public required int UserId { get; set; }

        // Navigation property section
        public User User { get; set; } = null!;

        public ICollection<Prediction> Predictions { get; set; } = null!;
    }
}
