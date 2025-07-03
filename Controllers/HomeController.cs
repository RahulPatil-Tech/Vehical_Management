using Microsoft.AspNetCore.Mvc;

namespace VehicleManagement.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
