namespace PROJET.Models
{
    public class Categorie
    {
        public int CategorieID { get; set; }
        public string CategorieName { get; set; }
        public ICollection<SousCategorie> ListSousCategories { get; set; }
    }
}
