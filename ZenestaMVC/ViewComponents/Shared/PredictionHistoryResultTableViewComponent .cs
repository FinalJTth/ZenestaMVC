using Microsoft.AspNetCore.Mvc;

using ZenestaMVC.Data;
using ZenestaMVC.Models.Entity;

namespace ZenestaMVC.ViewComponents.Shared
{
    public class PredictionHistoryResultTableViewComponent(ApplicationDBContext dBContext) : ViewComponent
    {
        private readonly ApplicationDBContext _dbContext = dBContext;

        private int? UserId => HttpContext.Session.GetInt32("UserId");

        public IViewComponentResult Invoke(int? chosenBatchId)
        {
            if (UserId is null)
            {
                throw new NullReferenceException("UserId session is null.");
            }

            PredictionBatch? predictionBatches = _dbContext.PredictionBatches
                .Where(batch => batch.UserId == UserId)
                .SingleOrDefault(batch => batch.Id == chosenBatchId);

            if (predictionBatches is not null)
            {
                _dbContext.Entry(predictionBatches).Collection(batch => batch.Predictions).Load();
                foreach (Prediction prediction in predictionBatches.Predictions)
                {
                    // Load the Publisher for the current Book.
                    _dbContext.Entry(prediction).Collection(pred => pred.PredictionResults).Load();

                    // Load the Genre for the current Book.
                    _dbContext.Entry(prediction).Reference(pred => pred.PredictionImage).Load();
                }

                return View(predictionBatches);
            }

            return View(new PredictionBatch { Id = 0, UserId = (int) UserId });
        }
    }
}
