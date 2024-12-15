using Microsoft.AspNetCore.Mvc;

using ZenestaMVC.Data;

namespace ZenestaMVC.ViewComponents.Shared
{
    public class PredictionHistoryResultTableViewComponent(ApplicationDBContext dBContext) : ViewComponent
    {
        private readonly ApplicationDBContext _dbContext = dBContext;

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
