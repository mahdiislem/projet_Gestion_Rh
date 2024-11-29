using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projet_Gestion_Rh.Models;

namespace projet_Gestion_Rh.Controllers
{
    [Authorize]

    public class CongeController : Controller
    {
        private readonly RhDBContext _dbContext;
        private readonly IWebHostEnvironment webHostEnvironment;




        public CongeController(RhDBContext dbContext, IWebHostEnvironment webHostEnvironment)
        {
            this._dbContext = dbContext;
            this.webHostEnvironment = webHostEnvironment;
        }
        // GET: CongeController
        public ActionResult Index()
        {

            List<Conge> conges = _dbContext.Conges.Include(x => x.Employe).ToList();
            foreach (var congé in conges)
            {
                TimeSpan duree = congé.DateFin - congé.DateDebut;
                congé.Duree = duree.TotalDays; 
            }

            return View(conges);
        }

        // GET: CongeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CongeController/Create
        public ActionResult Create()
        {
            ViewBag.EmployesList = _dbContext.Employes.ToList();

            return View();
        }

        // POST: CongeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Conge conge)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    if (_dbContext.Conges.Where(x => x.CongeId == conge.CongeId).Count() > 0)
                    {
                        ViewBag.errormessage = "le  conges est existe deja pour un employe";
                        return View(conge);
                    }
                    Conge c = new Conge();
                    c.Type = conge.Type;
                    _dbContext.Conges.Add(conge);
                    _dbContext.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                return View(conge);

            }
            catch
            {
                return View(conge);
            }

        }

        // GET: CongeController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.EmployesList = _dbContext.Employes.ToList();
            Conge con = _dbContext.Conges.Find(id);
            return View(con);
        }

        // POST: CongeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Conge conge)
        {
            try
            {
                Conge con = _dbContext.Conges.Find(id);
                con.Type = conge.Type;
                con.DateDebut = conge.DateDebut;
                con.DateFin = conge.DateFin;
                con.Status = conge.Status;
                con.EmployeId = conge.EmployeId;



                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            
            Conge conge = _dbContext.Conges
                .Include(c => c.Employe) 
                .FirstOrDefault(c => c.CongeId == id);

            if (conge == null)
            {
                return NotFound();
            }

            return View(conge);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Conge conge)
        {
            try
            {
                _dbContext.Conges.Remove(conge);
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
