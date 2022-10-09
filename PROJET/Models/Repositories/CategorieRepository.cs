namespace PROJET.Models.Repositories
{
    public class CategorieRepository : ICategorieRepository
    {
        readonly AppDbContext context;
        public CategorieRepository(AppDbContext context)
        {
            this.context = context;
        }
        public IList<Categorie> GetAll()
        {
            return context.Categories.OrderBy(catP => catP.CategorieName).ToList();
        }
        public Categorie GetById(int id)
        {
            return context.Categories.Find(id);
        }
        public void Add(Categorie catP)
        {
            context.Categories.Add(catP);
            context.SaveChanges();
        }
        public void Edit(Categorie catP)
        {
            Categorie catP1 = context.Categories.Find(catP.CategorieID);
            if (catP1 != null)
            {
                catP1.CategorieName = catP.CategorieName;
                context.SaveChanges();
            }
        }
        public void Delete(Categorie catP)
        {
            Categorie catP1 = context.Categories.Find(catP.CategorieID);
            if (catP1 != null)
            {
                context.Categories.Remove(catP1);
                context.SaveChanges();
            }
        }
        public int ProduitNb(int CategorieID)
        {
            return context.Categories.Where(catP => catP.CategorieID == CategorieID).Count();
        }
    }
}
