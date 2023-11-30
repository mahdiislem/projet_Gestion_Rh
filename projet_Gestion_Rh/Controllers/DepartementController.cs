using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projet_Gestion_Rh.Models;

namespace projet_Gestion_Rh.Controllers
{
    public class DepartementController : Controller
    {

        private readonly RhDBContext _dbContext;
        private readonly IWebHostEnvironment webHostEnvironment;




        public DepartementController(RhDBContext dbContext, IWebHostEnvironment webHostEnvironment)
        {
            this._dbContext = dbContext;
            this.webHostEnvironment = webHostEnvironment;
        }
        // GET: DepartementController
        public ActionResult Index()
        {
            List<Departement> departements = _dbContext.Departement.ToList();
            return View(departements);
        }

        // GET: DepartementController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DepartementController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartementController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: DepartementController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DepartementController/Edit/5
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

        // GET: DepartementController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DepartementController/Delete/5
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
