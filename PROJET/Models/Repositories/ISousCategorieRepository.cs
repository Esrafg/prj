namespace PROJET.Models.Repositories
{
    public interface ISousCategorieRepository
    {
        IList<SousCategorie> GetAll();
        SousCategorie GetById(int id);
        void Add(SousCategorie SouscatP);
        void Edit(SousCategorie SouscatP);
        void Delete(SousCategorie SouscatP);
        int ProduitNb(int SousCategorieID);
    }
}
