using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using healthsystem.Data;
using healthsystem.Models;

namespace healthsystem.Controllers
{

    [Authorize(Roles = "Admin")]
    public class WorkerTypeController : Controller
    {
      
        private readonly IRepositoryWrapper _repository;
        public WorkerTypeController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }
        // GET: WorkerTypeController
        public ActionResult Index()
        {
            ViewBag.Controller = "WorkerType";
            return View(_repository.WorkerType.FindAll());
        }

        // GET: WorkerTypeController/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.Controller = "WorkerType";
            return View(_repository.WorkerType.GetById(id));
        }

        // GET: WorkerTypeController/Create
        public ActionResult Create()
        {
            ViewBag.Controller = "WorkerType";
            return View();
        }

        // POST: WorkerTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WorkerType workerType)
        {
            ViewBag.Controller = "WorkerType";
            if (!ModelState.IsValid)
                return View(workerType);
            try
            {
                _repository.WorkerType.Create(workerType);
                _repository.WorkerType.Save();
                ViewBag.Message = "WorkerType created Successfully";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Failed to Add WorkerType");
                return View(workerType);
            }
        }

        // GET: WorkerTypeController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Controller = "WorkerType";
            return View(_repository.WorkerType.GetById(id));
        }

        // POST: WorkerTypeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, WorkerType _workerType)
        {
            ViewBag.Controller = "WorkerType";
            if (!ModelState.IsValid)
                return View(_workerType);

            var workerType = _repository.WorkerType.GetById(id);
            workerType.TypeName =  _workerType.TypeName;
            try
            {
                _repository.WorkerType.Create(workerType);
                _repository.WorkerType.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Failed to Update this WorkerType");
                return View(_workerType);
            }
        }

        // GET: WorkerTypeController/Delete/5
        public ActionResult Delete(int id)
        {
            ViewBag.Controller = "WorkerType";
            return View(_repository.WorkerType.GetById(id));
        }

        // POST: WorkerTypeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            ViewBag.Controller = "WorkerType";
            var WorkerType = _repository.WorkerType.GetById(id);
            try
            {
                _repository.WorkerType.Delete(WorkerType);
                _repository.WorkerType.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Failed to Delete this WorkerType");
                return View(WorkerType);
            }
        }
    }
}
