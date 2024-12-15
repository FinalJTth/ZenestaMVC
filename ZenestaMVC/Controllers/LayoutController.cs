using Microsoft.AspNetCore.Mvc;

using ZenestaMVC.Data;
using ZenestaMVC.Models;
using ZenestaMVC.Models.Entity;

namespace ZenestaMVC.Controllers
{
    public class LayoutController(ApplicationDBContext dbContext) : Controller
    {
        private readonly ApplicationDBContext _dbContext = dbContext;

        public IActionResult UserSession()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");

            if (userId is not null)
            {
                User sessionUser = _dbContext.Users.Single(user => user.Id == userId);

                return PartialView(new UserButtonLayoutViewComponentModel(sessionUser.Username));
            }

            return PartialView(new UserButtonLayoutViewComponentModel(""));
        }
    }
}
