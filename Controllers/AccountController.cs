using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;
using VehicleManagement.Data;
using VehicleManagement.Models;

namespace VehicleManagement.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users
                    .FirstOrDefault(u => u.UserName == login.UserName && u.Password == login.Password);

                if (user != null)
                {
                    HttpContext.Session.SetString("UserRole", user.Role);
                    HttpContext.Session.SetString("UserName", user.UserName);

                    if (user.Role == "Admin")
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Vehicle");
                    }
                }

                TempData["ErrorMessage"] = "Invalid username or password.";
            }

            return View(login);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_context.Users.Any(u => u.UserName == model.UserName))
                {
                    ModelState.AddModelError("UserName", "Username already exists. Please choose a different one.");
                    return View(model);
                }

                var newUser = new User
                {
                    UserName = model.UserName,
                    Password = model.Password,
                    Role = model.Role
                };

                _context.Users.Add(newUser);
                _context.SaveChanges();

                TempData["SuccessMessage"] = "Registration successful! Please log in.";
                return RedirectToAction("Login");
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            TempData["SuccessMessage"] = "You have been logged out successfully.";
            return RedirectToAction("Login");
        }
    }
}
