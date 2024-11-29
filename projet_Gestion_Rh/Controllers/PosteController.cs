using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projet_Gestion_Rh.Models;

namespace projet_Gestion_Rh.Controllers
{
    [Authorize]

    public class PosteController : Controller
    {


        private readonly RhDBContext _dbContext;
        private readonly IWebHostEnvironment webHostEnvironment;


        public PosteController(RhDBContext dbContext, IWebHostEnvironment webHostEnvironment)
        {
            this._dbContext = dbContext;
            this.webHostEnvironment = webHostEnvironment;
        }
        // GET: PosteController
        public ActionResult Index()
        {
            List<Poste> Postes = _dbContext.Postes.ToList();
            return View(Postes);
        }

        // GET: PosteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PosteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PosteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Poste poste)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    if (_dbContext.Postes.Where(x => x.Titre == poste.Titre).Count() > 0)
                    {
                        ViewBag.errormessage = "le poste existe";
                        return View(poste);
                    }
                    Poste p = new Poste();
                    p.Titre = poste.Titre;
                    p.Description = poste.Description;
                    p.salaire = poste.salaire;
                    _dbContext.Postes.Add(poste);
                    _dbContext.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                return View(poste);

            }
            catch
            {
                return View(poste);
            }

        }

        // GET: PosteController/Edit/5
        public ActionResult Edit(int id)
        {
            Poste poste = _dbContext.Postes.Find(id);
            return View(poste);
        }

        // POST: PosteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Poste poste)
        {
            try
            {
                Poste p = _dbContext.Postes.Find(id);
                p.Titre = poste.Titre;
                p.Description = poste.Description;
                p.salaire = poste.salaire;



                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PosteController/Delete/5
        public ActionResult Delete(int id)
        {
            Poste poste = _dbContext.Postes.Find(id);
            return View(poste);
        }

        // POST: PosteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Poste poste)
        {
            try
            {
                _dbContext.Postes.Remove(poste);
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
