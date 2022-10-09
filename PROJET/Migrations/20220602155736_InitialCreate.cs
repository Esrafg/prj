using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PROJET.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategorieID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategorieName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategorieID);
                });

            migrationBuilder.CreateTable(
                name: "Fournisseurs",
                columns: table => new
                {
                    FournisseurID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FournisseurName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fournisseurs", x => x.FournisseurID);
                });

            migrationBuilder.CreateTable(
                name: "SousCategories",
                columns: table => new
                {
                    SousCategorieID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SousCategorieName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategorieID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SousCategories", x => x.SousCategorieID);
                    table.ForeignKey(
                        name: "FK_SousCategories_Categories_CategorieID",
                        column: x => x.CategorieID,
                        principalTable: "Categories",
                        principalColumn: "CategorieID");
                });

            migrationBuilder.CreateTable(
                name: "Produits",
                columns: table => new
                {
                    ProduitID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProduitName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProduitCouleur = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProduitPrix = table.Column<double>(type: "float", nullable: false),
                    ProduitQteStock = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SousCategorieID = table.Column<int>(type: "int", nullable: false),
                    CategorieID = table.Column<int>(type: "int", nullable: false),
                    FournisseurID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produits", x => x.ProduitID);
                    table.ForeignKey(
                        name: "FK_Produits_Categories_CategorieID",
                        column: x => x.CategorieID,
                        principalTable: "Categories",
                        principalColumn: "CategorieID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Produits_Fournisseurs_FournisseurID",
                        column: x => x.FournisseurID,
                        principalTable: "Fournisseurs",
                        principalColumn: "FournisseurID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Produits_SousCategories_SousCategorieID",
                        column: x => x.SousCategorieID,
                        principalTable: "SousCategories",
                        principalColumn: "SousCategorieID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produits_CategorieID",
                table: "Produits",
                column: "CategorieID");

            migrationBuilder.CreateIndex(
                name: "IX_Produits_FournisseurID",
                table: "Produits",
                column: "FournisseurID");

            migrationBuilder.CreateIndex(
                name: "IX_Produits_SousCategorieID",
                table: "Produits",
                column: "SousCategorieID");

            migrationBuilder.CreateIndex(
                name: "IX_SousCategories_CategorieID",
                table: "SousCategories",
                column: "CategorieID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produits");

            migrationBuilder.DropTable(
                name: "Fournisseurs");

            migrationBuilder.DropTable(
                name: "SousCategories");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
