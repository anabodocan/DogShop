using Microsoft.EntityFrameworkCore.Migrations;

namespace DogShop.Migrations
{
    public partial class DogCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BreederID",
                table: "Dog",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Breeder",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BreederName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breeder", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DogCategory",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DogID = table.Column<int>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DogCategory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DogCategory_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DogCategory_Dog_DogID",
                        column: x => x.DogID,
                        principalTable: "Dog",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dog_BreederID",
                table: "Dog",
                column: "BreederID");

            migrationBuilder.CreateIndex(
                name: "IX_DogCategory_CategoryID",
                table: "DogCategory",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_DogCategory_DogID",
                table: "DogCategory",
                column: "DogID");

            migrationBuilder.AddForeignKey(
                name: "FK_Dog_Breeder_BreederID",
                table: "Dog",
                column: "BreederID",
                principalTable: "Breeder",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dog_Breeder_BreederID",
                table: "Dog");

            migrationBuilder.DropTable(
                name: "Breeder");

            migrationBuilder.DropTable(
                name: "DogCategory");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Dog_BreederID",
                table: "Dog");

            migrationBuilder.DropColumn(
                name: "BreederID",
                table: "Dog");
        }
    }
}
