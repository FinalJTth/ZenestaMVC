using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZenestaMVC.Models.Entity
{
    public class PredictionImage
    {
        [Key]
        public int Id { get; set; }

        public required string Name { get; set; }
        public required byte[] Data { get; set; }

        [ForeignKey(nameof(Prediction))]
        public required int PredictionId { get; set; }

        // Navigation property section
        public Prediction Prediction { get; set; } = null!;
    }
}
