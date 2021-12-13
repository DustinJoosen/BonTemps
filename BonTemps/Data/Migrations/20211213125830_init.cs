using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BonTemps.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Allergien",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Allergeen = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergien", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DrankSoorten",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Soort = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrankSoorten", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GerechtSoorten",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Soort = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GerechtSoorten", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Klanten",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    Naam = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    PostCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    Woonplaats = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klanten", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Klanten_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MenuSoorten",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Soort = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuSoorten", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vegetarisch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Soort = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vegetarisch", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dranken",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DrankSoortId = table.Column<int>(type: "int", nullable: false),
                    Naam = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Prijs = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dranken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dranken_DrankSoorten_DrankSoortId",
                        column: x => x.DrankSoortId,
                        principalTable: "DrankSoorten",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Gerechten",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GerechtSoortId = table.Column<int>(type: "int", nullable: false),
                    Naam = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gerechten", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gerechten_GerechtSoorten_GerechtSoortId",
                        column: x => x.GerechtSoortId,
                        principalTable: "GerechtSoorten",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reserveringen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tijd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KlantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserveringen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reserveringen_Klanten_KlantId",
                        column: x => x.KlantId,
                        principalTable: "Klanten",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuSoortId = table.Column<int>(type: "int", nullable: false),
                    Naam = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Prijs = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Menus_MenuSoorten_MenuSoortId",
                        column: x => x.MenuSoortId,
                        principalTable: "MenuSoorten",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ingredienten",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Eenheid = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    VegetarischId = table.Column<int>(type: "int", nullable: false),
                    AllergieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredienten", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingredienten_Allergien_AllergieId",
                        column: x => x.AllergieId,
                        principalTable: "Allergien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ingredienten_Vegetarisch_VegetarischId",
                        column: x => x.VegetarischId,
                        principalTable: "Vegetarisch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BestelRegels",
                columns: table => new
                {
                    ReserveringId = table.Column<int>(type: "int", nullable: false),
                    DrankId = table.Column<int>(type: "int", nullable: false),
                    Aantal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BestelRegels", x => new { x.DrankId, x.ReserveringId });
                    table.ForeignKey(
                        name: "FK_BestelRegels_Dranken_DrankId",
                        column: x => x.DrankId,
                        principalTable: "Dranken",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BestelRegels_Reserveringen_ReserveringId",
                        column: x => x.ReserveringId,
                        principalTable: "Reserveringen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuGerechten",
                columns: table => new
                {
                    MenuId = table.Column<int>(type: "int", nullable: false),
                    GerechtId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuGerechten", x => new { x.MenuId, x.GerechtId });
                    table.ForeignKey(
                        name: "FK_MenuGerechten_Gerechten_GerechtId",
                        column: x => x.GerechtId,
                        principalTable: "Gerechten",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuGerechten_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReserveringMenus",
                columns: table => new
                {
                    ReserveringId = table.Column<int>(type: "int", nullable: false),
                    MenuId = table.Column<int>(type: "int", nullable: false),
                    Aantal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReserveringMenus", x => new { x.MenuId, x.ReserveringId });
                    table.ForeignKey(
                        name: "FK_ReserveringMenus_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReserveringMenus_Reserveringen_ReserveringId",
                        column: x => x.ReserveringId,
                        principalTable: "Reserveringen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GerechtIngredienten",
                columns: table => new
                {
                    GerechtId = table.Column<int>(type: "int", nullable: false),
                    IngredientId = table.Column<int>(type: "int", nullable: false),
                    Aantal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GerechtIngredienten", x => new { x.GerechtId, x.IngredientId });
                    table.ForeignKey(
                        name: "FK_GerechtIngredienten_Gerechten_GerechtId",
                        column: x => x.GerechtId,
                        principalTable: "Gerechten",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GerechtIngredienten_Ingredienten_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredienten",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Allergien",
                columns: new[] { "Id", "Allergeen" },
                values: new object[,]
                {
                    { 1, "Ei" },
                    { 2, "Gluten" },
                    { 3, "Melk" },
                    { 4, "Sezamzaad" },
                    { 5, "Noten" },
                    { 6, "Pindas" },
                    { 7, "Mosterd" },
                    { 8, "Vis" }
                });

            migrationBuilder.InsertData(
                table: "DrankSoorten",
                columns: new[] { "Id", "Soort" },
                values: new object[,]
                {
                    { 3, "Kinderdranken" },
                    { 4, "Overige" },
                    { 1, "Alcohol" },
                    { 2, "Frisdrank" }
                });

            migrationBuilder.InsertData(
                table: "GerechtSoorten",
                columns: new[] { "Id", "Soort" },
                values: new object[,]
                {
                    { 1, "Voorgerecht" },
                    { 2, "Hoofdgerecht" },
                    { 3, "Nagerecht" },
                    { 4, "Bijgerecht" },
                    { 5, "Desert" }
                });

            migrationBuilder.InsertData(
                table: "MenuSoorten",
                columns: new[] { "Id", "Soort" },
                values: new object[,]
                {
                    { 1, "Lunch" },
                    { 2, "Dinner" }
                });

            migrationBuilder.InsertData(
                table: "Vegetarisch",
                columns: new[] { "Id", "Soort" },
                values: new object[,]
                {
                    { 4, "Pescotarier" },
                    { 1, "Vegetarier" },
                    { 2, "Veganist" },
                    { 3, "Flexitarier" },
                    { 5, "Pollotarier" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Allergien_Allergeen",
                table: "Allergien",
                column: "Allergeen",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BestelRegels_ReserveringId",
                table: "BestelRegels",
                column: "ReserveringId");

            migrationBuilder.CreateIndex(
                name: "IX_Dranken_DrankSoortId",
                table: "Dranken",
                column: "DrankSoortId");

            migrationBuilder.CreateIndex(
                name: "IX_Dranken_Naam",
                table: "Dranken",
                column: "Naam",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DrankSoorten_Soort",
                table: "DrankSoorten",
                column: "Soort",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Gerechten_GerechtSoortId",
                table: "Gerechten",
                column: "GerechtSoortId");

            migrationBuilder.CreateIndex(
                name: "IX_Gerechten_Naam",
                table: "Gerechten",
                column: "Naam",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GerechtIngredienten_IngredientId",
                table: "GerechtIngredienten",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_GerechtSoorten_Soort",
                table: "GerechtSoorten",
                column: "Soort",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ingredienten_AllergieId",
                table: "Ingredienten",
                column: "AllergieId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredienten_Naam",
                table: "Ingredienten",
                column: "Naam",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ingredienten_VegetarischId",
                table: "Ingredienten",
                column: "VegetarischId");

            migrationBuilder.CreateIndex(
                name: "IX_Klanten_Naam",
                table: "Klanten",
                column: "Naam");

            migrationBuilder.CreateIndex(
                name: "IX_Klanten_UserId",
                table: "Klanten",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MenuGerechten_GerechtId",
                table: "MenuGerechten",
                column: "GerechtId");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_MenuSoortId",
                table: "Menus",
                column: "MenuSoortId");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_Naam",
                table: "Menus",
                column: "Naam",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MenuSoorten_Soort",
                table: "MenuSoorten",
                column: "Soort",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reserveringen_KlantId",
                table: "Reserveringen",
                column: "KlantId");

            migrationBuilder.CreateIndex(
                name: "IX_ReserveringMenus_ReserveringId",
                table: "ReserveringMenus",
                column: "ReserveringId");

            migrationBuilder.CreateIndex(
                name: "IX_Vegetarisch_Soort",
                table: "Vegetarisch",
                column: "Soort",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BestelRegels");

            migrationBuilder.DropTable(
                name: "GerechtIngredienten");

            migrationBuilder.DropTable(
                name: "MenuGerechten");

            migrationBuilder.DropTable(
                name: "ReserveringMenus");

            migrationBuilder.DropTable(
                name: "Dranken");

            migrationBuilder.DropTable(
                name: "Ingredienten");

            migrationBuilder.DropTable(
                name: "Gerechten");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "Reserveringen");

            migrationBuilder.DropTable(
                name: "DrankSoorten");

            migrationBuilder.DropTable(
                name: "Allergien");

            migrationBuilder.DropTable(
                name: "Vegetarisch");

            migrationBuilder.DropTable(
                name: "GerechtSoorten");

            migrationBuilder.DropTable(
                name: "MenuSoorten");

            migrationBuilder.DropTable(
                name: "Klanten");
        }
    }
}
