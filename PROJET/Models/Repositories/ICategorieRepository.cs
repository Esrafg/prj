namespace PROJET.Models.Repositories
{
    public interface ICategorieRepository
    {
        IList<Categorie> GetAll();
        Categorie GetById(int id);
        void Add(Categorie catP);
        void Edit(Categorie catP);
        void Delete(Categorie catP);
        int ProduitNb(int CategorieID);
    }
}
