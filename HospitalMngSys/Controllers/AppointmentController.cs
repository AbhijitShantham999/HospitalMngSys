using Microsoft.AspNetCore.Mvc;
using HospitalMngSys.Models;
using HospitalMngSys.Repositories;

namespace HospitalMngSys.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointmentRepository _appRepo;

        public AppointmentController(IAppointmentRepository appRepo)
        {
            _appRepo = appRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var appList = await _appRepo.GetAll();
            return View(appList);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var appDet = await _appRepo.GetById(id);
            return View(appDet);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Appointment aptmt)
        {
            if (!ModelState.IsValid)
            {
                foreach (var entry in ModelState)
                {
                    foreach (var error in entry.Value.Errors)
                    {
                        Console.WriteLine($"Property: {entry.Key}, Error: {error.ErrorMessage}");
                    }
                }
                return View(aptmt);
            }

            await _appRepo.Add(aptmt);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var aptmt = await _appRepo.GetById(id);
            if (aptmt == null)
            {
                Console.WriteLine("Appointment Not Found");
                return NotFound();
            }
            return View(aptmt);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Appointment aptmt)
        {
            if (!ModelState.IsValid)
            {
                Console.WriteLine("Not Found");
                return View(aptmt);
            }
            await _appRepo.Update(aptmt);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var aptmt = await _appRepo.GetById(id);
            if (aptmt == null)
            {
                Console.WriteLine("Appointment Not Found");
                return NotFound();
            }
            await _appRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
