namespace PROJET.Models.Repositories
{
    public class FournisseurRepository : IFournisseurRepository
    {
        readonly AppDbContext context;
        public FournisseurRepository(AppDbContext context)
        {
            this.context = context;
        }
        public IList<Fournisseur> GetAll()
        {
            return context.Fournisseurs.OrderBy(f => f.FournisseurName).ToList();
        }
        public Fournisseur GetById(int id)
        {
            return context.Fournisseurs.Find(id);
        }
        public void Add(Fournisseur f)
        {
            context.Fournisseurs.Add(f);
            context.SaveChanges();
        }
        public void Edit(Fournisseur f)
        {
            Fournisseur f1 = context.Fournisseurs.Find(f.FournisseurID);
            if (f1 != null)
            {
                f1.FournisseurName = f.FournisseurName;
                context.SaveChanges();
            }
        }
        public void Delete(Fournisseur f)
        {
            Fournisseur f1 = context.Fournisseurs.Find(f.FournisseurID);
            if (f1 != null)
            {
                context.Fournisseurs.Remove(f1);
                context.SaveChanges();
            }
        }
        public int FournisseurNb(int FournisseurID)
        {
            return context.Fournisseurs.Where(f => f.FournisseurID == FournisseurID).Count();
        }
    }

}
