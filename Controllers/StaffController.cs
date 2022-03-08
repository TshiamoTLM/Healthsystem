using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using healthsystem.Data;
using healthsystem.Models;
using healthsystem.Models.ViewModels;
using System.Threading.Tasks;

namespace healthsystem.Controllers
{
    [Authorize(Roles = "Admin")]
    public class StaffController : Controller
    {
        private readonly IRepositoryWrapper _repository;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public StaffController(IRepositoryWrapper repository, 
            UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _repository = repository;
            _signInManager = signInManager;
            _userManager = userManager;
        }
        // GET: StaffController
        public ActionResult Index()
        {
            ViewBag.Controller = "HealthWorker";
            return View(_repository.HealthWorker.FindWithDependencies());
        }

        // GET: StaffController/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.Controller = "HealthWorker";
            var worker = _repository.HealthWorker.GetById(id);
            var workers = _repository.HealthWorker.FindWithDependencies();

            HealthWorker crworker = null;

            foreach (var item in workers)
            {
                if (item.HealthWorkerId == worker.HealthWorkerId)
                    crworker = item;
            }

            if (crworker == null)
                return NotFound();

            return View(crworker);
        }

        // GET: StaffController/Create
        public ActionResult Create()
        {
            ViewBag.Controller = "HealthWorker";
            ViewBag.WorkerTypeId = new SelectList(_repository.WorkerType.FindAll(), "WorkerTypeId", "TypeName");
            return View();
        }

        // POST: StaffController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(WorkerRegisterModel model)
        {
            ViewBag.Controller = "HealthWorker";
            try
            {
                if (ModelState.IsValid)
                {
                    var appUser = new AppUser
                    {
                        UserName = model.Email,
                        Email = model.Email
                    };

                    IdentityResult result = await _userManager.CreateAsync(appUser, model.Password);
                    if (result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(appUser, "HealthWorker");
                        _repository.HealthWorker.Create(new HealthWorker
                        {
                            Name = model.FullName,
                            WorkerTypeId = model.WorkerTypeId
                        });
                        _repository.HealthWorker.Save();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "unable to register user - (user already exists)");
                    }

                }
                ViewBag.WorkerTypeId = new SelectList(_repository.WorkerType.FindAll(), "WorkerTypeId", "TypeName");
                return View(model);
            }
            catch
            {
                return View();
            }
        }

        // GET: StaffController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Controller = "HealthWorker";
            ViewBag.WorkerTypeId = new SelectList(_repository.WorkerType.FindAll(), "WorkerTypeId", "TypeName");

            var worker = _repository.HealthWorker.GetById(id);
            if(worker == null)
                return NotFound();
            return View(worker);
        }

        // POST: StaffController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, HealthWorker _worker)
        {
            ViewBag.Controller = "HealthWorker";
            HealthWorker worker = _repository.HealthWorker.GetById(id);
            worker.Name = _worker.Name;
            worker.WorkerTypeId = _worker.WorkerTypeId;
            try
            {
                if (ModelState.IsValid)
                {
                    _repository.HealthWorker.Update(worker);

                    _repository.HealthWorker.Save();
                     ViewBag.Message = "HealthWorker Updated Successfully";

                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                ModelState.AddModelError("", "Failed to update health worker");
            }
            ViewBag.WorkerTypeId = new SelectList(_repository.WorkerType.FindAll(), "WorkerTypeId", "TypeName");
            return View();
        }

        // GET: StaffController/Delete/5
        public ActionResult Delete(int id)
        {
            ViewBag.Controller = "HealthWorker";
            var worker = _repository.HealthWorker.GetById(id);
            var workers = _repository.HealthWorker.FindWithDependencies();

            HealthWorker crworker = null;

            foreach (var item in workers)
            {
                if (item.HealthWorkerId == worker.HealthWorkerId)
                    crworker = item;
            }

            if (crworker == null)
                return NotFound();

            return View(crworker);
        }

        // POST: StaffController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            ViewBag.Controller = "HealthWorker";
            HealthWorker worker = _repository.HealthWorker.GetById(id);
            try
            {
                
                _repository.HealthWorker.Delete(worker);
                _repository.HealthWorker.Save();
                ViewBag.Message = "HealthWorker Deleted Successful";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Failed to delete HealthWorker");
                return View(worker);
            }
        }
    }
}
