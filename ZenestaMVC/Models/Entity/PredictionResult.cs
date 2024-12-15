using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZenestaMVC.Models.Entity
{
    public class PredictionResult
    {
        [Key]
        public int Id { get; set; }

        public string Object { get; set; } = null!;

        public float Confidence { get; set; }

        [ForeignKey(nameof(Prediction))]
        public required int PredictionId { get; set; }

        // Navigation property section
        public Prediction Prediction { get; set; } = null!;
    }
}
