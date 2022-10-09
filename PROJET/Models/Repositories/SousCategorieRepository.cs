namespace PROJET.Models.Repositories
{
    public class SousCategorieRepository : ISousCategorieRepository
    {
        readonly AppDbContext context;
    public SousCategorieRepository(AppDbContext context)
    {
        this.context = context;
    }
    public IList<SousCategorie> GetAll()
    {
        return context.SousCategories.OrderBy(SouscatP => SouscatP.SousCategorieName).ToList();
    }
    public SousCategorie GetById(int id)
    {
        return context.SousCategories.Find(id);
    }
    public void Add(SousCategorie SouscatP)
    {
        context.SousCategories.Add(SouscatP);
        context.SaveChanges();
    }
    public void Edit(SousCategorie SouscatP)
    {
        SousCategorie SouscatP1 = context.SousCategories.Find(SouscatP.SousCategorieID);
        if (SouscatP1 != null)
        {
            SouscatP1.SousCategorieName = SouscatP.SousCategorieName;
            context.SaveChanges();
        }
    }
    public void Delete(SousCategorie SouscatP)
    {
        SousCategorie SouscatP1 = context.SousCategories.Find(SouscatP.SousCategorieID);
        if (SouscatP1 != null)
        {
            context.SousCategories.Remove(SouscatP1);
            context.SaveChanges();
        }
    }
    public int ProduitNb(int SousCategorieID)
    {
        return context.SousCategories.Where(catP => catP.SousCategorieID == SousCategorieID).Count();
    }
}
   
}
