using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PROJET.Models;
using PROJET.Models.Repositories;

namespace PROJET.Controllers
{
    [Authorize]
    public class CategorieController : Controller
    {
       
        readonly ICategorieRepository CategorieRepository;
        public CategorieController(ICategorieRepository CategorieRepository)
        {
            this.CategorieRepository = CategorieRepository;
        }
        

        // GET: CategorieProduitController
        public ActionResult Index()
        {
            return View(CategorieRepository.GetAll());
        }
        [AllowAnonymous]
        // GET: CategorieProduitController/Details/5
        public ActionResult Details(int id)
        {
            var categP = CategorieRepository.GetById(id);
            return View(categP);
        }

        // GET: CategorieProduitController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategorieProduitController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categorie catP)
        {
            try
            {
                CategorieRepository.Add(catP);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategorieProduitController/Edit/5
        public ActionResult Edit(int id)
        {
            var categP = CategorieRepository.GetById(id);
            return View(categP);
        }

        // POST: CategorieProduitController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categorie catP)
        {
            try
            {
                CategorieRepository.Edit(catP);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategorieProduitController/Delete/5
        public ActionResult Delete(int id)
        {
            var categP = CategorieRepository.GetById(id);
            return View(categP);
        }

        // POST: CategorieProduitController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Categorie catP)
        {
            try
            {
                CategorieRepository.Delete(catP);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}