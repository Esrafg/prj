namespace PROJET.Models
{
    public class Produit
    {
        public int ProduitID { get; set; }
        public string ProduitName { get; set; }
        public string ProduitCouleur { get; set; }
        public double ProduitPrix{ get; set; }
        public string ProduitQteStock{ get; set; }

        public int SousCategorieID { get; set; }
        public SousCategorie SousCategorieP { get; set; }
        public int CategorieID { get; set; }
        public Categorie CategorieP { get; set; }
        public int FournisseurID { get; set; }
        public Fournisseur FournisseurP { get; set; }

    }
}
