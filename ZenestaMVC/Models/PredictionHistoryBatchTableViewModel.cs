using ZenestaMVC.Models.Entity;

namespace ZenestaMVC.Models
{
    public class PredictionHistoryBatchTableViewModel(int page, int? chosenBatchId, List<PredictionBatch> predictionBatches)
    {
        public int Page { get; set; } = page;
        public int? ChosenBatchId { get; set; } = chosenBatchId;
        public List<PredictionBatch> PredictionBatches { get; set; } = predictionBatches;
    }
}
