using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http; // Required for HttpContext.Session
using Microsoft.EntityFrameworkCore; // Required for .Include() and .ToListAsync(), .FindAsync()
using System.Linq; // Required for LINQ queries like FirstOrDefault, Any
using System.Threading.Tasks; // Required for async/await
using VehicleManagement.Data; // Your DbContext
using VehicleManagement.Models; // Your Vehicle and User models

namespace VehicleManagement.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        // Constructor for dependency injection of ApplicationDbContext
        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Checks if the currently logged-in user has the "Admin" role.
        /// This relies on the "UserRole" being set in the session during login.
        /// </summary>
        /// <returns>True if the user is an Admin, false otherwise.</returns>
        private bool IsAdmin()
        {
            return HttpContext.Session.GetString("UserRole") == "Admin";
        }

        /// <summary>
        /// Helper method to redirect unauthorized users to the login page.
        /// Sets an error message in TempData for user feedback.
        /// </summary>
        /// <returns>A RedirectToActionResult to the Account Login page.</returns>
        private IActionResult RedirectToLogin()
        {
            TempData["ErrorMessage"] = "You must be logged in as an administrator to access this page.";
            return RedirectToAction("Login", "Account");
        }

        // GET: Admin/Index
        /// <summary>
        /// Displays the Admin Dashboard, listing all registered vehicles.
        /// Only accessible by users with the "Admin" role.
        /// </summary>
        /// <returns>The AdminIndex view with a list of all vehicles.</returns>
        public async Task<IActionResult> Index()
        {
            // Security check: Only Admins can view the admin dashboard
            if (!IsAdmin())
            {
                return RedirectToLogin();
            }

            // Fetch all vehicles and include their associated user data
            // This is efficient for displaying user names alongside vehicles
            var vehicles = await _context.Vehicles.Include(v => v.User).ToListAsync();
            return View("AdminIndex", vehicles); // Ensure you have an AdminIndex.cshtml view
        }

        // GET: Admin/AddVehicle
        /// <summary>
        /// Displays the form to add a new vehicle.
        /// Only accessible by Admins. Populates a list of users for assignment.
        /// </summary>
        /// <returns>The AddVehicle view.</returns>
        [HttpGet]
        public IActionResult AddVehicle()
        {
            if (!IsAdmin())
            {
                return RedirectToLogin();
            }
            // Populate ViewBag.Users with all users for the dropdown
            ViewBag.Users = _context.Users.ToList();
            return View();
        }

        // POST: Admin/AddVehicle
        /// <summary>
        /// Handles the submission of the Add Vehicle form.
        /// Saves a new vehicle to the database.
        /// </summary>
        /// <param name="vehicle">The Vehicle model submitted from the form.</param>
        /// <returns>
        /// Redirects to the Admin Dashboard (Index action) on successful addition.
        /// If validation fails, returns the AddVehicle view with errors.
        /// </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddVehicle(Vehicle vehicle)
        {
            if (!IsAdmin())
            {
                return RedirectToLogin();
            }

            if (ModelState.IsValid)
            {
                _context.Add(vehicle);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Vehicle added successfully!";
                return RedirectToAction(nameof(Index));
            }
            // If ModelState is not valid, re-populate ViewBag.Users before returning the view
            ViewBag.Users = _context.Users.ToList();
            return View(vehicle);
        }

        // GET: Admin/EditVehicle/5
        /// <summary>
        /// Displays the form to edit an existing vehicle.
        /// Only accessible by Admins. Fetches the specific vehicle and all users for assignment.
        /// </summary>
        /// <param name="id">The ID of the vehicle to edit.</param>
        /// <returns>The EditVehicle view.</returns>
        [HttpGet]
        public async Task<IActionResult> EditVehicle(int? id)
        {
            if (!IsAdmin())
            {
                return RedirectToLogin();
            }

            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicles.FindAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }

            // *** IMPORTANT: Populate ViewBag.Users here ***
            ViewBag.Users = await _context.Users.ToListAsync(); // Fetch all users for the dropdown
            return View(vehicle);
        }

        // POST: Admin/EditVehicle/5
        /// <summary>
        /// Handles the submission of the Edit Vehicle form.
        /// Updates an existing vehicle's details in the database.
        /// </summary>
        /// <param name="id">The ID of the vehicle being edited (from route data).</param>
        /// <param name="vehicle">The updated Vehicle model submitted from the form.</param>
        /// <returns>
        /// Redirects to the Admin Dashboard (Index action) on successful update.
        /// If validation fails or the vehicle is not found, returns the EditVehicle view with errors.
        /// </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditVehicle(int id, [Bind("Id,RegistrationNumber,Make,Model,Type,Status,LastMaintenanceDate,UserId")] Vehicle vehicle)
        {
            if (!IsAdmin())
            {
                return RedirectToLogin();
            }

            // Check if the ID from the route matches the ID in the form data
            if (id != vehicle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicle);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Vehicle updated successfully!";
                }
                catch (DbUpdateConcurrencyException)
                {
                    // If the vehicle doesn't exist in the database, return Not Found.
                    if (!_context.Vehicles.Any(e => e.Id == vehicle.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw; // Re-throw other concurrency exceptions
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            // If ModelState is not valid, re-populate ViewBag.Users before returning the view
            ViewBag.Users = await _context.Users.ToListAsync();
            return View(vehicle);
        }


        // GET: Admin/DeleteVehicle/5
        /// <summary>
        /// Displays the confirmation page for deleting a vehicle.
        /// Only accessible by Admins.
        /// </summary>
        /// <param name="id">The ID of the vehicle to be deleted.</param>
        /// <returns>The DeleteVehicle view.</returns>
        [HttpGet]
        public async Task<IActionResult> DeleteVehicle(int? id)
        {
            // Security check: Only Admins can access this action
            if (!IsAdmin())
            {
                return RedirectToLogin();
            }

            // If no ID is provided, return a 404 Not Found response.
            if (id == null) return NotFound();

            // Find the vehicle by its ID, including the associated User for display.
            var vehicle = await _context.Vehicles
                                        .Include(v => v.User)
                                        .FirstOrDefaultAsync(m => m.Id == id);
            // If the vehicle is not found, return a 404 Not Found response.
            if (vehicle == null) return NotFound();

            // Return the DeleteVehicle view, passing the found vehicle as the model.
            return View(vehicle);
        }

        // POST: Admin/DeleteVehicle/5
        /// <summary>
        /// Handles the deletion of a vehicle after confirmation.
        /// Only accessible by Admins.
        /// </summary>
        /// <param name="id">The ID of the vehicle to delete.</param>
        /// <returns>
        /// Redirect to the Admin Dashboard (Index action) on successful deletion.
        /// If the user is not an Admin or the vehicle is not found, redirects to login or returns NotFound.
        /// </returns>
        [HttpPost, ActionName("DeleteVehicle")] // Matches the GET action name for consistency in routing
        [ValidateAntiForgeryToken] // Protects against Cross-Site Request Forgery attacks
        public async Task<IActionResult> DeleteConfirmed(int id) // Method name can be different from action name
        {
            // Security check: Only Admins can delete vehicles
            if (!IsAdmin())
            {
                return RedirectToLogin();
            }

            // Find the vehicle by its ID. FindAsync is efficient for primary key lookups.
            var vehicle = await _context.Vehicles.FindAsync(id);
            // If the vehicle is not found, return a 404 Not Found response.
            if (vehicle == null) return NotFound();

            // Remove the vehicle from the database context.
            _context.Vehicles.Remove(vehicle);
            // Save changes asynchronously to the database.
            await _context.SaveChangesAsync();

            // Set a success message to be displayed on the redirected page.
            TempData["SuccessMessage"] = "Vehicle deleted successfully!";
            // Redirect to the Admin Dashboard (Index action).
            return RedirectToAction(nameof(Index));
        }
    }
}