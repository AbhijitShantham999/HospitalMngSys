using System.Diagnostics;
using HospitalMngSys.Models;
using Microsoft.AspNetCore.Mvc;

namespace HospitalMngSys.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly HospitalMngSysDbContext _context;

        public HomeController(ILogger<HomeController> logger, HospitalMngSysDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.TotalPatients = _context.Patients.Count();
            ViewBag.TotalDoctors = _context.Doctors.Count();
            ViewBag.TotalScheduled = _context.Appointments.Where(app => app.Status == "Scheduled").ToList().Count();
            ViewBag.TotalCompleted = _context.Appointments.Where(app => app.Status == "Completed").ToList().Count();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
