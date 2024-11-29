using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using NuGet.Protocol;
using projet_Gestion_Rh.Models;
using System;
using System.Drawing.Drawing2D;
using System.Web;
using static NuGet.Packaging.PackagingConstants;

namespace projet_Gestion_Rh.Controllers
{

    [Authorize]
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
        public ActionResult Index(string search)
        {
            IQueryable<Employe> query = _dbContext.Employes.Include(x => x.Departement).Include(y=>y.Poste);

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(e => e.NomPrenom.Contains(search));
            }

            List<Employe> employes = query.ToList();
            return View(employes);
        }


        // GET: EmployeController/Details/5
        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            Employe employee = _dbContext.Employes
                .Include(e => e.Departement)
                .Include(e => e.Poste)
                .FirstOrDefault(e => e.EmployeId == id);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }


        // GET: EmployeController/Create
        public ActionResult Create(Departement departement)
        {
            ViewBag.DepartementsList = _dbContext.Departements.ToList();
            ViewBag.PostesList = _dbContext.Postes.ToList();

            return View();
        }

        // POST: EmployeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employe employe)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    if (_dbContext.Employes.Where(x => x.NomPrenom == employe.NomPrenom).Count() > 0)
                    {
                        ViewBag.errormessage = "L'employee existe deja !";
                        return View(employe);
                    }

                    string folder = "image/cover/";
                    folder += Guid.NewGuid().ToString() + "_" + employe.imageFile.FileName;
                    string serverFolder = Path.Combine(webHostEnvironment.WebRootPath, folder);
                    //folder
                    employe.Image = folder;
                    employe.imageFile.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                    _dbContext.Employes.Add(employe);
                    _dbContext.SaveChanges();
                    return RedirectToAction(nameof(Index));


                }
                return View(employe);


            }
            catch
            {
                return View(employe);
            }
        }


        // GET: EmployeController/Edit/5
        public IActionResult Edit(int id)
        {
            ViewBag.DepartementsList = _dbContext.Departements.ToList();
            ViewBag.PostesList = _dbContext.Postes.ToList();

            Employe emp = _dbContext.Employes.Find(id);
            return View(emp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Employe e)
        {
            try
            {
                Employe emp = _dbContext.Employes.Find(id);
                if (e.imageFile != null)
                {
                    if (!string.IsNullOrEmpty(emp.Image))
                    {
                        string filepath = Path.Combine(webHostEnvironment.WebRootPath, "image/cover", emp.Image);
                        if (System.IO.File.Exists(filepath))
                        {
                            System.IO.File.Delete(filepath);
                        }
                    }

                    string folder = "image/cover/";
                    folder += Guid.NewGuid().ToString() + "_" + e.imageFile.FileName;
                    string serverFolder = Path.Combine(webHostEnvironment.WebRootPath, folder);

                    // Update the e.Image property
                    e.Image = folder;

                    e.imageFile.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                }

                emp.NomPrenom = e.NomPrenom;
                emp.DateNaissance = e.DateNaissance;
                emp.Genre = e.Genre;
                emp.Telephone = e.Telephone;
                emp.Adresse = e.Adresse;
                emp.Email = e.Email;
                emp.DateEmbauche = e.DateEmbauche;
                emp.Image = e.Image;
                emp.DepartementId = e.DepartementId;
                emp.PosteId = e.PosteId;


                _dbContext.Employes.Update(emp);
                _dbContext.SaveChanges();
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
            Employe employe = _dbContext.Employes
      .Include(e => e.Departement)
      .Include(e => e.Poste)
      .FirstOrDefault(e => e.EmployeId == id);
            Employe emplo = _dbContext.Employes.Find(id);
            return View(emplo);
        }

        // POST: EmployeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Employe employe)
        {
            try
            {
                _dbContext.Employes.Remove(employe);
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
