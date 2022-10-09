
namespace PROJET.Models.Repositories
{
    public interface IProduitRepository
    {
        IList<Produit> GetAll();
        Produit GetById(int id);
        void Add(Produit p);
        void Edit(Produit p);
        void Delete(Produit p);
        IList<Produit> GetProduitBySousCategorieID(int? SousCategorieID);
        IList<Produit> GetProduitByCategorieID(int? CategorieID);
        IList<Produit> GetProduitByFournisseurID(int? FournisseurID);
        IList<Produit> FindByName(string name);
    }
}
