using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PROJET.Models.Repositories;
using PROJET.Models;
using Microsoft.AspNetCore.Authorization;

namespace PROJET.Controllers
{
    [Authorize]
    public class ProduitController : Controller
    {
        readonly IFournisseurRepository FournisseurRepository;
        readonly ICategorieRepository CategorieRepository;
        readonly ISousCategorieRepository SousCategorieRepository;
        readonly IProduitRepository ProduitRepository;
        public ProduitController(IFournisseurRepository FournisseurRepository, ICategorieRepository CategorieRepository, IProduitRepository ProduitRepository, ISousCategorieRepository SousCategorieRepository)
        {
            this.FournisseurRepository = FournisseurRepository;
            this.CategorieRepository = CategorieRepository;
            this.ProduitRepository = ProduitRepository;
            this.SousCategorieRepository = SousCategorieRepository;
        }
        [AllowAnonymous]
        // GET: ProduitController
        public ActionResult Index()
        {
            ViewBag.SousCategorieID = new SelectList(SousCategorieRepository.GetAll(), "SousCategorieID", "SousCategorieName");
            ViewBag.CategorieID = new SelectList(CategorieRepository.GetAll(), "CategorieID", "CategorieName");
            ViewBag.FournisseurID = new SelectList(FournisseurRepository.GetAll(), "FournisseurID", "FournisseurName");
            return View(ProduitRepository.GetAll());
        }
        public ActionResult Search(string name, int? CategorieID)
        {
            var result = ProduitRepository.GetAll();
            if (!string.IsNullOrEmpty(name))
                result = ProduitRepository.FindByName(name);
            else
            if (CategorieID != null)
                result = ProduitRepository.GetProduitByCategorieID(CategorieID);
            ViewBag.SousCategorieID = new SelectList(SousCategorieRepository.GetAll(), "SousCategorieID", "SousCategorieName");
            ViewBag.CategorieID = new SelectList(CategorieRepository.GetAll(), "CategorieID", "CategorieName");
            ViewBag.FournisseurID = new SelectList(FournisseurRepository.GetAll(), "FournisseurID", "FournisseurName");
            return View("Index", result);
        }

        // GET: ProduitController/Details/5
        public ActionResult Details(int id)
        {
            return View(ProduitRepository.GetById(id));
        }

        // GET: ProduitController/Create
        public ActionResult Create()
        {
            ViewBag.SousCategorieID = new SelectList(SousCategorieRepository.GetAll(), "SousCategorieID", "SousCategorieName"); 
            ViewBag.CategorieID = new SelectList(CategorieRepository.GetAll(), "CategorieID", "CategorieName");
            ViewBag.FournisseurID = new SelectList(FournisseurRepository.GetAll(), "FournisseurID", "FournisseurName");
            return View();
        }

        // POST: ProduitController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Produit p)
        {
            try
            {
                ViewBag.SousCategorieID = new SelectList(SousCategorieRepository.GetAll(), "SousCategorieID", "SousCategorieName", p.SousCategorieID);
                ViewBag.CategorieID = new SelectList(CategorieRepository.GetAll(), "CategorieID", "CategorieName", p.CategorieID);
                ViewBag.FournisseurID = new SelectList(FournisseurRepository.GetAll(), "FournisseurID", "FournisseurName", p.FournisseurID);
                ProduitRepository.Add(p);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProduitController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.SousCategorieID = new SelectList(SousCategorieRepository.GetAll(), "SousCategorieID", "SousCategorieName");
            ViewBag.CategorieID = new SelectList(CategorieRepository.GetAll(), "CategorieID", "CategorieName");
            ViewBag.FournisseurID = new SelectList(FournisseurRepository.GetAll(), "FournisseurID", "FournisseurName");
            return View(ProduitRepository.GetById(id));
        }
        // POST: ProduitController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Produit p)
        {
            try
            {
                ViewBag.SousCategorieID = new SelectList(SousCategorieRepository.GetAll(), "SousCategorieID", "SousCategorieName");
                ViewBag.CategorieID = new SelectList(CategorieRepository.GetAll(), "CategorieID", "CategorieName");
                ViewBag.FournisseurID = new SelectList(FournisseurRepository.GetAll(), "FournisseurID", "FournisseurName");
                ProduitRepository.Edit(p);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProduitController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(ProduitRepository.GetById(id));
        }

        // POST: ProduitController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Produit p)
        {
            try
            {
                ProduitRepository.Delete(p);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}