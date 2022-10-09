namespace PROJET.Models.Repositories
{
    public interface IFournisseurRepository
    {
        IList<Fournisseur> GetAll();
        Fournisseur GetById(int id);
        void Add(Fournisseur f);
        void Edit(Fournisseur f);
        void Delete(Fournisseur f);
        int FournisseurNb(int FournisseurID);
    }
}
