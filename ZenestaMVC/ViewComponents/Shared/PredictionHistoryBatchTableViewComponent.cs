using Microsoft.AspNetCore.Mvc;

using ZenestaMVC.Data;
using ZenestaMVC.Models;
using ZenestaMVC.Models.Entity;

namespace ZenestaMVC.ViewComponents.Shared
{
    public class PredictionHistoryBatchTableViewComponent(ApplicationDBContext dBContext) : ViewComponent
    {
        private readonly ApplicationDBContext _dbContext = dBContext;

        private int? UserId => HttpContext.Session.GetInt32("UserId");

        public IViewComponentResult Invoke(int page, int? chosenBatchId)
        {
            List<PredictionBatch> predictionBatches = _dbContext.PredictionBatches
                .Where(batch => batch.UserId == UserId)
                .OrderByDescending(batch => batch.DatePublished)
                .Skip((page - 1) * 10)
                .Take(10)
                .ToList();

            return View(new PredictionHistoryBatchTableViewModel(page, chosenBatchId, predictionBatches));
        }
    }
}
