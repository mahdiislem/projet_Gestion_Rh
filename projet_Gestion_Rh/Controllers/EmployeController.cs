﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using projet_Gestion_Rh.Models;

namespace projet_Gestion_Rh.Controllers
{
    public class EmployeController : Controller
    {

        private readonly RhDBContext _dbContext;
        private readonly IWebHostEnvironment webHostEnvironment;




       public EmployeController(RhDBContext dbContext, IWebHostEnvironment webHostEnvironment)
        {
            this._dbContext = dbContext;
            this.webHostEnvironment = webHostEnvironment;   
        }
        // GET: EmployeController
        public ActionResult Index()
        {
            return View();
        }

        // GET: EmployeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmployeController/Create
        public ActionResult Create(Departement departement)
        {
            ViewBag.DepartementsList = _dbContext.Departement.ToList();

            return View();
        }

        // POST: EmployeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create()
        {
            //ViewBag.DepartementsList = _dbContext.Departements.ToList();

            return View();
        }

        // GET: EmployeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmployeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
