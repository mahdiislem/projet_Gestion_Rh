using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projet_Gestion_Rh.Models;

namespace projet_Gestion_Rh.Controllers
{
    [Authorize]

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
            List<Departement> departements = _dbContext.Departements.ToList();
            return View(departements);
        }

        // GET: DepartementController
        public ActionResult GetEmploye(int id)
        {
            List<Employe> ListEmpl = new List<Employe>(); 
            foreach(Employe e in _dbContext.Employes.ToList())
            {
                if(e.DepartementId == id)
                {
                   
                    ListEmpl.Add(e);
                    
                }
            }
            return View(ListEmpl);
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
        public ActionResult Create(Departement departement)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    if (_dbContext.Departements.Where(x => x.Nom == departement.Nom).Count() > 0)
                    {
                        ViewBag.errormessage = "le departement existe";
                        return View(departement);
                    }
                    Departement s = new Departement();
                    s.Nom = departement.Nom;
                    _dbContext.Departements.Add(departement);
                    _dbContext.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                return View(departement);

            }
            catch
            {
                return View(departement);
            }
        }





        // GET: DepartementController/Edit/5
        public ActionResult Edit(int id)
        {
            Departement depart = _dbContext.Departements.Find(id);
            return View(depart);
        }

        // POST: DepartementController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Departement departement)
        {

            try
            {
                Departement depart = _dbContext.Departements.Find(id);
                depart.Nom = departement.Nom;
                depart.Description = departement.Description;
                depart.NomResponsable = departement.NomResponsable;



                _dbContext.SaveChanges();
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
            Departement depart = _dbContext.Departements.Find(id);
            return View(depart);
        }

        // POST: DepartementController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Departement departement)
        {
            try
            {
                _dbContext.Departements.Remove(departement);
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
