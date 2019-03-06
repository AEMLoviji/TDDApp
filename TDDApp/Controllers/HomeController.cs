using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TDDApp.Models;
using TDDApp.Repositories;

namespace TDDApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPersonRepository _repository;

        public HomeController(IPersonRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
        {
            var model = _repository.GetList();
            if (model.Any())
            {
                ViewBag.Message = $"{model.Count} Person object in database.";
            }

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Person person)
        {
            if (ModelState.IsValid)
            {
                _repository.Create(person);
                _repository.Save();
                return RedirectToAction("Index");
            }

            return View("Create");
        }

        protected override void Dispose(bool disposing)
        {
            _repository.Dispose();
            base.Dispose(disposing);
        }
    }
}