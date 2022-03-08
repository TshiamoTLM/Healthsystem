using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using healthsystem.Data;
using healthsystem.Models;

namespace healthsystem.Controllers
{
    [Authorize]
    public class ReminderController : Controller
    {
        private readonly IRepositoryWrapper _repository;
        public ReminderController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }
        public ActionResult Index()
        {
            ViewBag.Controller = " Reminder";
            return View(_repository.Reminder.FindWithDependencies());
        }

        // GET: NewsFeedController/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.Controller = " Reminder";
            var reminders = _repository.Reminder.FindWithDependencies();
            var reminder = _repository.Reminder.GetById(id);

            foreach (var item in reminders)
            {
                if(item.Id == reminder.Id)
                    reminder = item;
            }
            return View(reminder);
        }

        // GET: NewsFeedController/Create
        public ActionResult Create()
        {
            ViewBag.Controller = " Reminder";
            ViewBag.ConsultationId = new SelectList(_repository.Consultation.FindAll(), "ConsultationId", "Date");
            return View();
        }

        // POST: NewsFeedController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Reminder collection)
        {
            ViewBag.Controller = " Reminder";
            ViewBag.ConsultationId = new SelectList(_repository.Consultation.FindAll(), "ConsultationId", "Date");
            if (!ModelState.IsValid)
                return View(collection);
            try
            {
                collection.userId = User.Identity.Name;
                _repository.Reminder.Create(collection);
                _repository.Reminder.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Failed to create Reminder");
                return View(collection);
            }
        }

        // GET: NewsFeedController/Edit/5
 
        public ActionResult Edit(int id)
        {
            ViewBag.Controller = " Reminder";

            var reminders = _repository.Reminder.FindWithDependencies();
            var reminder = _repository.Reminder.GetById(id);

            foreach (var item in reminders)
            {
                if (item.Id == reminder.Id)
                    reminder = item;
            }
            return View(reminder);
        }

        // POST: NewsFeedController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Reminder collection)
        {
            ViewBag.Controller = " Reminder";
            ViewBag.ConsultationId = new SelectList(_repository.Consultation.FindAll(), "ConsultationId", "Date");
            if (!ModelState.IsValid)
                return View(collection);

            var reminder = _repository.Reminder.GetById(id);
            reminder.ConsultationId = collection.ConsultationId;
            reminder.Details = collection.Details;
            reminder.userId = User.Identity.Name;

            try
            {
                _repository.Reminder.Update(reminder);
                _repository.Reminder.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Failed to update this Reminder");
                return View(collection);
            }
        }

        // GET: NewsFeedController/Delete/5
        public ActionResult Delete(int id)
        {
            ViewBag.Controller = "Reminder";
            var reminders = _repository.Reminder.FindWithDependencies();
            var reminder = _repository.Reminder.GetById(id);

            foreach (var item in reminders)
            {
                if (item.Id == reminder.Id)
                    reminder = item;
            }
            return View(reminder);
        }

        // POST: NewsFeedController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            ViewBag.Controller = " Reminder";
            var reminder = _repository.Reminder.GetById(id);
            try
            {
                _repository.Reminder.Delete(reminder);
                _repository.Reminder.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Failed to Delete Reminder");
                return View(reminder);
            }
        }
    }
}
