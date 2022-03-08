using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using healthsystem.Data;
using healthsystem.Models;

namespace healthsystem.Controllers
{
    //[Authorize(Roles="Admin,HealthWorker")]
    [Authorize]
    public class PatientTypeController : Controller
    {
        private readonly IRepositoryWrapper _repository;
        public PatientTypeController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }
        // GET: PatientTypeController
        public ActionResult Index()
        {
            ViewBag.Controller = "PatientType";
            return View(_repository.PatientType.FindAll());
        }

        // GET: PatientTypeController/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.Controller = "PatientType";
            return View(_repository.PatientType.GetById(id));
        }

        // GET: PatientTypeController/Create
        public ActionResult Create()
        {
            ViewBag.Controller = "PatientType";
            return View();
        }

        // POST: PatientTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PatientType patientType)
        {
            ViewBag.Controller = "PatientType";
            try
            {
                if(!ModelState.IsValid)
                    return View(patientType);

               _repository.PatientType.Create(patientType);
                _repository.PatientType.Save();
                ViewBag.Message = "Patient Type Saved Successfully";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Failed to Add new Patient Type");
                return View(patientType);
            }
        }

        // GET: PatientTypeController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Controller = "PatientType";
            return View(_repository.PatientType.GetById(id));
        }

        // POST: PatientTypeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PatientType _patientType)
        {
            ViewBag.Controller = "PatientType";
            PatientType patientType = _repository.PatientType.GetById(id);
            patientType.TypeName = _patientType.TypeName;
            try
            {
                _repository.PatientType.Update(patientType);
                _repository.PatientType.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Failed to Update PatientType");
                return View(_patientType);
            }
        }

        // GET: PatientTypeController/Delete/5
        public ActionResult Delete(int id)
        {
            ViewBag.Controller = "PatientType";
            return View(_repository.PatientType.GetById(id));
        }

        // POST: PatientTypeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            ViewBag.Controller = "PatientType";
            var type = _repository.PatientType.GetById(id);

            try
            {
                _repository.PatientType.Delete(type);
                _repository.PatientType.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Failed to delete Patient Type");
                return View(type);
            }
        }
    }
}
