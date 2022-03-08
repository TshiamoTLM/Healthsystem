using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using healthsystem.Data;
using healthsystem.Models;
using System;

namespace healthsystem.Controllers
{
    [Authorize]

    public class PatientController : Controller
    {
        private readonly IRepositoryWrapper _repository;

        public PatientController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }
        public IActionResult Profile()
        {
            ViewBag.Controller = "Patient";
            var userEmail = User.Identity.Name;
            var user = _repository.AppUser.GetByEmail(userEmail);

            var patients = _repository.Patient.FindWithDependencies();
            Patient pat = null;
            foreach (var item in patients)
            {
                if(item.IdNumber == user.IdNumber)
                    pat = item;
            }

            //if(pat == null) 
            //    return NotFound();

            return View(pat);
        }
        public IActionResult Index()
        {
            ViewBag.Controller = "Patient";
            return View(_repository.Patient.FindWithDependencies());
        }

        // GET: PatientController/Details/5
        [HttpGet]
       
        public ActionResult Details(int id)
        {
            ViewBag.Controller = "Patient";
            var pat = _repository.Patient.GetById(id);
            var pats = _repository.Patient.FindWithDependencies();

            Patient patient = null;

            foreach (var item in pats)
            {
                if (item.PatientId == pat.PatientId)
                    patient = item;
            }

            if (patient == null)
                return NotFound();

            return View(pat);
        }

        // GET: PatientTypeController/Create
        [HttpGet]
        //[Authorize(Roles = "Admin,HealthWorker")]
        public ActionResult Create()
        {
            ViewBag.Controller = "Patient";
            ViewBag.ConsultationId = new SelectList(_repository.Consultation.FindAll(), "ConsultationId", "Date");
            ViewBag.HealthWorkerId = new SelectList(_repository.HealthWorker.FindAll(), "HealthWorkerId", "Name");
            ViewBag.PatientTypeId = new SelectList(_repository.PatientType.FindAll(), "PatientTypeId", "TypeName");
            ViewBag.HealthWorkerId = new SelectList(_repository.HealthWorker.FindAll(), "HealthWorkerId", "Name");
            return View();
        }

        // POST: PatientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "Admin,HealthWorker")]
        public ActionResult Create(Patient patient)
        {
            ViewBag.Controller = "Patient";
            try
            {
                if (ModelState.IsValid)
                {
                    var pats = _repository.Patient.FindAll();
                    foreach (var item in pats)
                    {
                        if (item.IdNumber == patient.IdNumber) {
                            ModelState.AddModelError("", $"Patient with ID Number: {patient.IdNumber} Already Exists!");

                           
                            ViewBag.ConsultationId = new SelectList(_repository.Consultation.FindAll(), "ConsultationId", "Date");
                            ViewBag.HealthWorkerId = new SelectList(_repository.HealthWorker.FindAll(), "HealthWorkerId", "Name");
                            ViewBag.PatientTypeId = new SelectList(_repository.PatientType.FindAll(), "PatientTypeId", "TypeName");
                            ViewBag.HealthWorkerId = new SelectList(_repository.HealthWorker.FindAll(), "HealthWorkerId", "Name");

                            return View(patient);
                        }
                    }

                    _repository.Patient.Create(patient);
                    _repository.Patient.Save();
                    ViewBag.Message = "New Record Added Successfully";
                    return RedirectToAction(nameof(Index));
                }
      
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
             
            }
            ViewBag.ConsultationId = new SelectList(_repository.Consultation.FindAll(), "ConsultationId", "Date");
            ViewBag.HealthWorkerId = new SelectList(_repository.HealthWorker.FindAll(), "HealthWorkerId", "Name");
            ViewBag.PatientTypeId = new SelectList(_repository.PatientType.FindAll(), "PatientTypeId", "TypeName");
            ViewBag.HealthWorkerId = new SelectList(_repository.HealthWorker.FindAll(), "HealthWorkerId", "Name");
            return View(patient);
        }

        // GET: PatientController/Edit/5

        public ActionResult Edit(int id)
        {
            ViewBag.Controller = "Patient";
            ViewBag.ConsultationId = new SelectList(_repository.Consultation.FindAll(), "ConsultationId", "Date");
            ViewBag.HealthWorkerId = new SelectList(_repository.HealthWorker.FindAll(), "HealthWorkerId", "Name");
            ViewBag.PatientTypeId = new SelectList(_repository.PatientType.FindAll(), "PatientTypeId", "TypeName");
            ViewBag.HealthWorkerId = new SelectList(_repository.HealthWorker.FindAll(), "HealthWorkerId", "Name");
            var pat = _repository.Patient.GetById(id);
            if (pat == null)
                return NotFound();

            return View(pat);
        }

        // POST: PatientController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Patient _patient)
        {
            ViewBag.Controller = "Patient";
            Patient patient = _repository.Patient.GetById(id);
            patient.PatientTypeId = _patient.PatientTypeId;
            patient.IdNumber = _patient.IdNumber;
            patient.campusID = _patient.campusID;
            patient.Cellphone = _patient.Cellphone;
            try
            {
                if (ModelState.IsValid)
                {
                    _repository.Patient.Update(patient);

                    _repository.Patient.Save();
                    ViewBag.Message = "Patient Updated Successfully";

                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                ModelState.AddModelError("", "Failed to edit Patient");
            }
            ViewBag.ConsultationId = new SelectList(_repository.Consultation.FindAll(), "ConsultationId", "Date");
            ViewBag.HealthWorkerId = new SelectList(_repository.HealthWorker.FindAll(), "HealthWorkerId", "Name");
            ViewBag.PatientTypeId = new SelectList(_repository.PatientType.FindAll(), "PatientTypeId", "TypeName");
            ViewBag.HealthWorkerId = new SelectList(_repository.HealthWorker.FindAll(), "HealthWorkerId", "Name");
            return View(patient);
        }

        // GET: PatientController/Delete/5
        //[Authorize(Roles = "Admin,HealthWorker")]
        public ActionResult Delete(int id)
        {
            ViewBag.Controller = "Patient";
            var pat = _repository.Patient.GetById(id);
            var pats = _repository.Patient.FindWithDependencies();

            Patient patient = null;

            foreach (var item in pats)
            {
                if (item.PatientId == pat.PatientId)
                    patient = item;
            }

            if (patient == null)
                return NotFound();

            return View(pat);
        }

        // POST: PatientController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "Admin,HealthWorker")]
        public ActionResult Delete(int id, Patient _patient)
        {
            ViewBag.Controller = "Patient";
            Patient patient = _repository.Patient.GetById(id);

            try
            {
                _repository.Patient.Delete(patient);
                _repository.Patient.Save();
                ViewBag.Message = "Patient Deleted Successful";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Failed to delete Patient");
                return View(patient);
            }
        }
    }
}
