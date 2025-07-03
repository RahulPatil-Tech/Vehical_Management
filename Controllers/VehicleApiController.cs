using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using VehicleManagement.Data;
using VehicleManagement.Models;

namespace VehicleManagement.Controllers
{
    public class VehicleController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VehicleController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ✔ Helpers
        private bool IsUserLoggedIn() =>
            !string.IsNullOrEmpty(HttpContext.Session.GetString("UserName"));

        private User? GetLoggedInUser()
        {
            var username = HttpContext.Session.GetString("UserName");
            if (string.IsNullOrEmpty(username)) return null;
            return _context.Users.FirstOrDefault(u => u.UserName == username);
        }

        // 📄 INDEX
        public IActionResult Index()
        {
            if (!IsUserLoggedIn()) return RedirectToAction("Login", "Account");

            var user = GetLoggedInUser();
            if (user == null) return Unauthorized();

            var vehicles = _context.Vehicles
                .Where(v => v.UserId == user.Id)
                .ToList();

            return View("UserDashboard", vehicles);
        }

        // 📄 DETAILS
        public IActionResult Details(int? id)
        {
            if (!IsUserLoggedIn()) return RedirectToAction("Login", "Account");
            if (id == null) return NotFound();

            var user = GetLoggedInUser();
            if (user == null) return Unauthorized();

            var vehicle = _context.Vehicles.FirstOrDefault(v => v.Id == id && v.UserId == user.Id);
            if (vehicle == null) return NotFound();

            return View(vehicle);
        }

        // 📄 CREATE
        public IActionResult Create()
        {
            if (!IsUserLoggedIn()) return RedirectToAction("Login", "Account");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Vehicle vehicle)
        {
            if (!IsUserLoggedIn()) return RedirectToAction("Login", "Account");

            var user = GetLoggedInUser();
            if (user == null) return Unauthorized();

            if (ModelState.IsValid)
            {
                vehicle.UserId = user.Id; // link to logged-in user
                _context.Vehicles.Add(vehicle);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Vehicle created!";
                return RedirectToAction(nameof(Index));
            }

            return View(vehicle);
        }

        // 📄 EDIT
        public IActionResult Edit(int? id)
        {
            if (!IsUserLoggedIn()) return RedirectToAction("Login", "Account");
            if (id == null) return NotFound();

            var user = GetLoggedInUser();
            if (user == null) return Unauthorized();

            var vehicle = _context.Vehicles.FirstOrDefault(v => v.Id == id && v.UserId == user.Id);
            if (vehicle == null) return NotFound();

            return View(vehicle);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Vehicle vehicle)
        {
            if (!IsUserLoggedIn()) return RedirectToAction("Login", "Account");

            var user = GetLoggedInUser();
            if (user == null) return Unauthorized();

            if (id != vehicle.Id) return NotFound();

            var existing = _context.Vehicles.FirstOrDefault(v => v.Id == id && v.UserId == user.Id);
            if (existing == null) return NotFound();

            if (ModelState.IsValid)
            {
                existing.RegistrationNumber = vehicle.RegistrationNumber;
                existing.Make = vehicle.Make;
                existing.Model = vehicle.Model;
                existing.Type = vehicle.Type;
                existing.Status = vehicle.Status;
                existing.LastMaintenanceDate = vehicle.LastMaintenanceDate;

                _context.SaveChanges();
                TempData["SuccessMessage"] = "Vehicle updated!";
                return RedirectToAction(nameof(Index));
            }

            return View(vehicle);
        }

        // 📄 DELETE
        public IActionResult Delete(int? id)
        {
            if (!IsUserLoggedIn()) return RedirectToAction("Login", "Account");
            if (id == null) return NotFound();

            var user = GetLoggedInUser();
            if (user == null) return Unauthorized();

            var vehicle = _context.Vehicles.FirstOrDefault(v => v.Id == id && v.UserId == user.Id);
            if (vehicle == null) return NotFound();

            return View(vehicle);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (!IsUserLoggedIn()) return RedirectToAction("Login", "Account");

            var user = GetLoggedInUser();
            if (user == null) return Unauthorized();

            var vehicle = _context.Vehicles.FirstOrDefault(v => v.Id == id && v.UserId == user.Id);
            if (vehicle == null) return NotFound();

            _context.Vehicles.Remove(vehicle);
            _context.SaveChanges();
            TempData["SuccessMessage"] = "Vehicle deleted!";
            return RedirectToAction(nameof(Index));
        }

        // 📄 ADD MAINTENANCE
        public IActionResult AddMaintenance(int? id)
        {
            if (!IsUserLoggedIn()) return RedirectToAction("Login", "Account");
            if (id == null) return NotFound();

            var user = GetLoggedInUser();
            if (user == null) return Unauthorized();

            var vehicle = _context.Vehicles.FirstOrDefault(v => v.Id == id && v.UserId == user.Id);
            if (vehicle == null) return NotFound();

            return View(vehicle);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddMaintenance(int id, DateTime newMaintenanceDate)
        {
            if (!IsUserLoggedIn()) return RedirectToAction("Login", "Account");

            var user = GetLoggedInUser();
            if (user == null) return Unauthorized();

            var vehicle = _context.Vehicles.FirstOrDefault(v => v.Id == id && v.UserId == user.Id);
            if (vehicle == null) return NotFound();

            if (newMaintenanceDate == default)
                ModelState.AddModelError("newMaintenanceDate", "Date required.");
            else if (newMaintenanceDate > DateTime.Today)
                ModelState.AddModelError("newMaintenanceDate", "Cannot be in the future.");

            if (ModelState.IsValid)
            {
                vehicle.LastMaintenanceDate = newMaintenanceDate;
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Maintenance updated!";
                return RedirectToAction(nameof(Details), new { id = vehicle.Id });
            }

            return View(vehicle);
        }
    }
}
