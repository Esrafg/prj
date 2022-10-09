using Microsoft.EntityFrameworkCore;

namespace PROJET.Models.Repositories
{
    public class ProduitRepository : IProduitRepository
    {
        readonly AppDbContext context;
        public ProduitRepository(AppDbContext context)
        {
            this.context = context;
        }
        public IList<Produit> GetAll()
        {
            return context.Produits.OrderBy(x => x.ProduitName).Include(x => x.CategorieP).ToList();
        }
        public Produit GetById(int id)
        {
            return context.Produits.Where(x => x.ProduitID == id).Include(x => x.CategorieP).SingleOrDefault();
        }
        public void Add(Produit P)
        {
            context.Produits.Add(P);
            context.SaveChanges();
        }
        public void Edit(Produit P)
        {
            Produit P1 = context.Produits.Find(P.ProduitID);
            if (P1 != null)
            {
                P1.ProduitName = P.ProduitName;
                P1.ProduitCouleur = P.ProduitCouleur;
                P1.ProduitPrix = P.ProduitPrix;
                P1.ProduitQteStock = P.ProduitQteStock;
                P1.CategorieID = P.CategorieID;
                P1.SousCategorieID = P.SousCategorieID;
                P1.FournisseurID = P.FournisseurID;
                context.SaveChanges();
            }
        }
        public void Delete(Produit P)
        {
            Produit P1 = context.Produits.Find(P.ProduitID);
            if (P1 != null)
            {
                context.Produits.Remove(P1);
                context.SaveChanges();
            }
        }
        public IList<Produit> GetProduitByCategorieID(int? CategorieProduitID)
        {
            return context.Produits.Where(catP =>
            catP.CategorieID.Equals(CategorieProduitID)).OrderBy(s => s.ProduitName).Include(std => std.CategorieP).ToList();
        }

        public IList<Produit> GetProduitByFournisseurID(int? FournisseurID)
        {
            return context.Produits.Where(f =>
            f.FournisseurID.Equals(FournisseurID)).OrderBy(f => f.ProduitName).Include(std => std.FournisseurP).ToList();
        }

        public IList<Produit> FindByName(string name)
        {
            return context.Produits.Where(catP =>
            catP.ProduitName.Contains(name)).Include(P => P.CategorieP).ToList();
        }

        IList<Produit> IProduitRepository.GetProduitBySousCategorieID(int? SousCategorieID)
        {
            return context.Produits.Where(SouscatP =>
        SouscatP.SousCategorieID.Equals(SousCategorieID)).OrderBy(s => s.ProduitName)
        .Include(std => std.SousCategorieP).ToList();
        }
    }

}
