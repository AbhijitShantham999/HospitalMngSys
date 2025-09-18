using HospitalMngSys.Models;
using HospitalMngSys.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HospitalMngSys.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientRepository _patientRepo;
        public PatientController(IPatientRepository patientRepo) {
            _patientRepo = patientRepo;
        }
        public async Task<IActionResult> Index()
        {
            var PateintList = await _patientRepo.GetAll();
            return View(PateintList);
        }

        //Details
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var patient = await _patientRepo.GetById(id);
            return View(patient);
        }

        //Create

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Patient patient)
        {
            if (ModelState.IsValid)
            {
                Console.WriteLine("✅ Saving to DB....");
                await _patientRepo.Add(patient);
                return RedirectToAction("Index");
            }

            // 🔥 Print all validation errors to console
            foreach (var state in ModelState)
            {
                foreach (var error in state.Value.Errors)
                {
                    Console.WriteLine($"❌ Field: {state.Key}, Error: {error.ErrorMessage}");
                }
            }

            Console.WriteLine("❌ Form Submission Failed");
            return View(patient);
        }


        //Edit

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var patient = await _patientRepo.GetById(id);
            if (patient == null)
            {
                Console.WriteLine("Patient not found");
                return NotFound();
            }
            return View(patient);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Patient patient)
        {
            if (!ModelState.IsValid)
            {
                return View(patient);
            }
            await _patientRepo.Update(patient);
            return RedirectToAction("Index");
        }

        //Delete

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _patientRepo.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
