using Microsoft.AspNetCore.Mvc;

using ZenestaMVC.Data;
using ZenestaMVC.Models;
using ZenestaMVC.Models.Entity;
using ZenestaMVC.Services;

namespace ZenestaMVC.Controllers
{
    public class MLController(ApplicationDBContext dbContext, MLService mLService) : Controller
    {
        private readonly ApplicationDBContext _dbContext = dbContext;
        private readonly MLService _mLService = mLService;

        private int? UserId => HttpContext.Session.GetInt32("UserId");

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PredictionHistory(int? page, int? chosenBatchId)
        {
            if (UserId == null)
            {
                return RedirectToAction("Login", "User");
            }

            // Return not found if either page or chosenBatchId is 0 or negative.
            if (page < 1 || chosenBatchId < 1)
            {
                return NotFound();
            }

            // If page is null (not supplied) then just use page 1
            page ??= 1;

            // When page "and" chosenBatchId are null or non position
            /*
            if (chosenBatchId is null && page is null)
            {
                page = 1;
                chosenBatchId = _dbContext.PredictionBatches
                    .OrderByDescending(batch => batch.DatePublished)
                    .Select(batch => batch.Id)
                    .FirstOrDefault();
            // When only chosenBatchId is null or non position
            if ((chosenBatchId is null or < 1) && (page is not null and not < 1))
            {
                chosenBatchId = _dbContext.PredictionBatches
                    .OrderByDescending(batch => batch.DatePublished)
                    .Select(batch => batch.Id)
                    .Skip(((int) page) * 10)
                    .FirstOrDefault();
            }

            // After assigning id, if the prediction batch is still null then return not found.
            if (chosenBatchId is null or < 1)
            {
                return NotFound();
            }

            // When only page is null or non position
            if ((chosenBatchId is not null and not < 1) && (page is null or < 1))
            {
                int index = _dbContext.PredictionBatches
                    .Where(batch => batch.DatePublished > _dbContext.PredictionBatches.Single(batch => batch.Id == chosenBatchId).DatePublished)
                    .Count();

                page = 1 + (index / 10);
            }
            */

            int entryNumber = _dbContext.PredictionBatches.Where(batch => batch.UserId == UserId).Count();

            return View(new PredictionHistoryViewModel((int) page, chosenBatchId, 1 + (entryNumber / 10)));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Predict(PredictionForm predictionForm)
        {
            if (UserId == null)
            {
                return Json(new { redirectUrl = Url.Action("Login", "User") });
            }

            // Send prediction request to ML server for each image and store the return list of prediction dictionary in that list.
            List<List<Dictionary<string, string>>> predictionList = new();
            foreach (IFormFile image in predictionForm.Images)
            {
                // Sending request
                List<Dictionary<string, string>> predictionResult = await _mLService.GetPrediction(image);

                predictionList.Add(predictionResult);
            }

            // Make a new prediction batch and update database.
            PredictionBatch newBatch = new() { Name = predictionForm.BatchName, DatePublished = DateTime.Now, UserId = (int) UserId };
            _dbContext.PredictionBatches.Add(newBatch);
            _dbContext.SaveChanges();

            // For each prediction of an image
            for (int i = 0; i < predictionList.Count; i++)
            {
                List<Dictionary<string, string>> resultPayload = predictionList[i];

                // Make a prediction model to store in database.
                Prediction prediction = new() { PredictionBatchId = newBatch.Id };
                _dbContext.Predictions.Add(prediction);
                // Save change to get the prediction id for foreign key.
                _dbContext.SaveChanges();

                IFormFile image = predictionForm.Images[i];
                using MemoryStream memoryStream = new();
                image.OpenReadStream().CopyTo(memoryStream);

                PredictionImage predictionImage = new() { Name = image.FileName, Data = memoryStream.ToArray(), PredictionId = prediction.Id };
                _dbContext.PredictionImages.Add(predictionImage);

                // Make several prediction result (one prediction always contain 5 results) model to store in database.
                IEnumerable<PredictionResult> predictionResults = resultPayload
                    .Select(result => new PredictionResult { Object = result["object"], Confidence = float.Parse(result["confidence"]), PredictionId = prediction.Id });

                _dbContext.PredictionResults.AddRange(predictionResults);
            }

            _dbContext.SaveChanges();

            // return json for javascript redirection
            return Json(new { redirectUrl = Url.Action("PredictionHistory", "ML", new { pageNumber = 1, predictionBatchId = newBatch.Id }) });
        }
    }
}
