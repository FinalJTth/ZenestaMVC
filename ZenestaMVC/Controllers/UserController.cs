using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System.Net.Mail;

using ZenestaMVC.Data;
using ZenestaMVC.Models;
using ZenestaMVC.Models.Entity;

namespace ZenestaMVC.Controllers
{
    public class UserController(ApplicationDBContext dbContext) : Controller
    {
        private readonly ApplicationDBContext _dbContext = dbContext;

        public IActionResult Index()
        {
            return View();
        }

        // GET /User/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST /User/Login : When the user press submit button on login page
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(UserLoginForm loginForm)
        {
            User loginUser;

            if (ModelState.IsValid)
            {
                loginUser = _dbContext.Users.Single(user => user.Username == loginForm.UserId || user.Email == loginForm.UserId);
                if (VerifyLoginPassword(loginUser.Username, loginUser.Password, loginForm.Password))
                {
                    HttpContext.Session.SetInt32("UserId", loginUser.Id);
                }
            }

            return ModelState.IsValid ? RedirectToAction("Index", "Home") : View();
        }

        // GET POST /User/Login : Validate Username field
        [AllowAnonymous]
        [AcceptVerbs("Get", "Post")]
        public JsonResult VerifyLoginUsername(string userId)
        {
            return MailAddress.TryCreate(userId, out _)
                ? _dbContext.Users.Any(user => user.Email == userId) ? Json(true) : Json($"The email doesn't exist.")
                : _dbContext.Users.Any(user => user.Username == userId) ? Json(true) : Json($"The username doesn't exist.");
        }

        // None : Validate Password field and manually add error to ModelState
        public bool VerifyLoginPassword(string username, string userHashedPassword, string loginPassword)
        {
            if (ModelState.IsValid)
            {
                if (!BCrypt.Net.BCrypt.EnhancedVerify(loginPassword, userHashedPassword))
                {
                    ModelState.AddModelError("Password", "Your password is incorrect.");
                    return false;
                }

                return true;
            }

            return false;
        }

        // GET /User/Register
        public IActionResult Register()
        {
            return View();
        }

        // POST /User/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(UserRegisterForm registerForm)
        {
            if (ModelState.IsValid)
            {
                string hashedPassword = BCrypt.Net.BCrypt.EnhancedHashPassword(registerForm.Password, 13);

                _dbContext.Users.Add(new User(registerForm.Username, hashedPassword, registerForm.Email, registerForm.DateOfBirth, registerForm.Age));
                _dbContext.SaveChanges();

                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [AllowAnonymous]
        [AcceptVerbs("Get", "Post")]
        public JsonResult VerifyRegisterUsername(string username)
        {
            return _dbContext.Users.Any(user => user.Username == username) ? Json($"Username already exists.") : Json(true);
        }

        [AllowAnonymous]
        [AcceptVerbs("Get", "Post")]
        public JsonResult VerifyRegisterEmail(string email)
        {
            return _dbContext.Users.Any(user => user.Email == email) ? Json($"Email already exists.") : Json(true);
        }
    }
}
