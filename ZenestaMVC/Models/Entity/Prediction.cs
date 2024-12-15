using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZenestaMVC.Models.Entity
{
    public class Prediction
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(PredictionBatch))]
        public required int PredictionBatchId { get; set; }

        // Navigation property section
        public PredictionBatch PredictionBatch { get; set; } = null!;

        public ICollection<PredictionResult> PredictionResults { get; set; } = null!;

        public PredictionImage PredictionImage { get; set; } = null!;
    }
}
