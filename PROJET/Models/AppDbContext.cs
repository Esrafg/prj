using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PROJET.Models;

namespace PROJET.Models
{
      public class AppDbContext : IdentityDbContext
        {
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
            {
            }
            public DbSet<Produit> Produits { get; set; }
            public DbSet<Categorie> Categories { get; set; }
            public DbSet<Fournisseur> Fournisseurs { get; set; }
            public DbSet<SousCategorie> SousCategories { get; set; }
        }
    
}
