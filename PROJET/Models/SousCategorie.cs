namespace PROJET.Models
{
    public class SousCategorie
    {
        public int SousCategorieID { get; set; }
        public string SousCategorieName { get; set; }
        public ICollection<Produit> ListProduits { get; set; }
    }
}
