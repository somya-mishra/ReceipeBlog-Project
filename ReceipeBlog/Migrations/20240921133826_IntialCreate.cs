using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReceipeBlog.Migrations
{
    public partial class IntialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FoodReceipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceipeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceipeDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodReceipes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngredientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FoodReceipeIngredients",
                columns: table => new
                {
                    FoodReceipeId = table.Column<int>(type: "int", nullable: false),
                    IngredientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodReceipeIngredients", x => new { x.FoodReceipeId, x.IngredientId });
                    table.ForeignKey(
                        name: "FK_FoodReceipeIngredients_FoodReceipes_FoodReceipeId",
                        column: x => x.FoodReceipeId,
                        principalTable: "FoodReceipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodReceipeIngredients_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodReceipeIngredients_IngredientId",
                table: "FoodReceipeIngredients",
                column: "IngredientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodReceipeIngredients");

            migrationBuilder.DropTable(
                name: "FoodReceipes");

            migrationBuilder.DropTable(
                name: "Ingredients");
        }
    }
}
