namespace ZenestaMVC.Models
{
    public class PredictionHistoryViewModel(int page, int? chosenBatchId, int maxPage)
    {
        public int Page { get; set; } = page;
        public int? ChosenBatchId { get; set; } = chosenBatchId;

        public int MaxPage { get; set; } = maxPage;
    }
}
