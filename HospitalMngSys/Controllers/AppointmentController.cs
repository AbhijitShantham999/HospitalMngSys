using Microsoft.AspNetCore.Mvc;

namespace HospitalMngSys.Controllers
{
    public class AppointmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
