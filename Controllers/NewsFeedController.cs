using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using healthsystem.Data;
using healthsystem.Models;

namespace healthsystem.Controllers
{
    [Authorize]
    public class NewsFeedController : Controller
    {
        private readonly IRepositoryWrapper _repository;
        public NewsFeedController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }
        // GET: NewsFeedController
        public ActionResult Index()
        {
            ViewBag.Controller = "NewsFeed";
            return View(_repository.NewsFeed.FindAll());
        }

        // GET: NewsFeedController/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.Controller = "NewsFeed";
            return View(_repository.NewsFeed.GetById(id));
        }

        // GET: NewsFeedController/Create
        //[Authorize(Roles = "Admin,HealthWorker")]
        public ActionResult Create()
        {
            ViewBag.Controller = "NewsFeed";
            return View();
        }

        // POST: NewsFeedController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "Admin,HealthWorker")]
        public ActionResult Create(NewsFeed collection)
        {
            ViewBag.Controller = "NewsFeed";
            if (!ModelState.IsValid)
                return View(collection);
            try
            {
                collection.PostDate = System.DateTime.Now.Date;
                _repository.NewsFeed.Create(collection);
                _repository.NewsFeed.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Failed to create NewsFeed");
                return View(collection);
            }
        }

        // GET: NewsFeedController/Edit/5
        //[Authorize(Roles = "Admin,HealthWorker")]
        public ActionResult Edit(int id)
        {
            ViewBag.Controller = "NewsFeed";
            return View(_repository.NewsFeed.GetById(id));
        }

        // POST: NewsFeedController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "Admin,HealthWorker")]
        public ActionResult Edit(int id, NewsFeed collection)
        {
            ViewBag.Controller = "NewsFeed";
            if (!ModelState.IsValid)
                return View(collection);

            var newsfeed = _repository.NewsFeed.GetById(id);
            newsfeed.Title = collection.Title;
            newsfeed.Description = collection.Description;
            newsfeed.PostDate = System.DateTime.Now.Date;
          
            try
            {
                _repository.NewsFeed.Update(newsfeed);
                _repository.NewsFeed.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Failed to update this NewsFeed");
                return View(collection);
            }
        }

        // GET: NewsFeedController/Delete/5
        //[Authorize(Roles = "Admin,HealthWorker")]
        public ActionResult Delete(int id)
        {
            ViewBag.Controller = "NewsFeed";
            return View();
        }

        // POST: NewsFeedController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,HealthWorker")]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            ViewBag.Controller = "NewsFeed";
            var newsfeed = _repository.NewsFeed.GetById(id);
            try
            {
                _repository.NewsFeed.Delete(newsfeed);
                _repository.NewsFeed.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
