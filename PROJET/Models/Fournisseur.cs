namespace PROJET.Models
{
    public class Fournisseur
    {
        public int FournisseurID { get; set; }
        public string FournisseurName { get; set; }
        public ICollection<Produit> ListProduits { get; set; }


    }
}
