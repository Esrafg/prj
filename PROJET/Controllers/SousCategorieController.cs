using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PROJET.Models;
using PROJET.Models.Repositories;

namespace PROJET.Controllers
{
    [Authorize]
    public class SousCategorieController : Controller
    {
        readonly ISousCategorieRepository SousCategorieRepository;
        public SousCategorieController(ISousCategorieRepository SousCategorieRepository)
        {
            this.SousCategorieRepository = SousCategorieRepository;
        }
        // GET: SousCategorieProduitController
        public ActionResult Index()
        {
            return View(SousCategorieRepository.GetAll());
        }
        [AllowAnonymous]

        // GET: SousCategorieProduitController/Details/5
        public ActionResult Details(int id)
        {
            var SouscategP = SousCategorieRepository.GetById(id);
            return View(SouscategP);
        }

        // GET: SousCategorieProduitController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SousCategorieProduitController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SousCategorie SouscatP)
        {
            try
            {
                SousCategorieRepository.Add(SouscatP);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SousCategorieProduitController/Edit/5
        public ActionResult Edit(int id)
        {
            var SouscategP = SousCategorieRepository.GetById(id);
            return View(SouscategP);
        }

        // POST: SousCategorieProduitController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SousCategorie SouscatP)
        {
            try
            {
                SousCategorieRepository.Edit(SouscatP);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SousCategorieProduitController/Delete/5
        public ActionResult Delete(int id)
        {
            var SouscategP = SousCategorieRepository.GetById(id);
            return View(SouscategP);
        }

        // POST: SousCategorieProduitController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(SousCategorie SouscatP)
        {
            try
            {
                SousCategorieRepository.Delete(SouscatP);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
