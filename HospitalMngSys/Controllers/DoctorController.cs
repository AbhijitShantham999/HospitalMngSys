using Microsoft.AspNetCore.Mvc;
using HospitalMngSys.Repositories;
using HospitalMngSys.Models;

namespace HospitalMngSys.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorRepository _docRepo; 
        public DoctorController(IDoctorRepository docRepo)
        {
            _docRepo = docRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var docList = await _docRepo.GetAll();
            return View(docList);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Doctor doc)
        {
            if (!ModelState.IsValid)
            {
                return View(doc);
            }

            await _docRepo.Add(doc);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var docDetails = await _docRepo.GetById(id);
            return View(docDetails);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var doc = await _docRepo.GetById(id);
            if (doc == null)
            {
                Console.WriteLine("Doctor Not Found");
            }
            return View(doc);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Doctor doc)
        {
            if (!ModelState.IsValid)
            {
                Console.WriteLine("Invalid");
            }

            await _docRepo.Update(doc);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _docRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
