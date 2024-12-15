using Microsoft.AspNetCore.Mvc;

using ZenestaMVC.Data;
using ZenestaMVC.Models;
using ZenestaMVC.Models.Entity;

namespace ZenestaMVC.ViewComponents.Shared
{
    public class UserButtonLayoutViewComponent(ApplicationDBContext dBContext) : ViewComponent
    {
        private readonly ApplicationDBContext _dbContext = dBContext;

        public IViewComponentResult Invoke()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");

            if (userId is not null)
            {
                User sessionUser = _dbContext.Users.Single(user => user.Id == userId);

                return View(new UserButtonLayoutViewComponentModel(sessionUser.Username));
            }

            return View(new UserButtonLayoutViewComponentModel(""));
        }
    }
}
