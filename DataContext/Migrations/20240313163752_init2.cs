using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataContext.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RecipeUser",
                columns: table => new
                {
                    RecipesEditedByTheUserId = table.Column<int>(type: "int", nullable: false),
                    UsersLikedId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeUser", x => new { x.RecipesEditedByTheUserId, x.UsersLikedId });
                    table.ForeignKey(
                        name: "FK_RecipeUser_Recipes_RecipesEditedByTheUserId",
                        column: x => x.RecipesEditedByTheUserId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeUser_Users_UsersLikedId",
                        column: x => x.UsersLikedId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecipeUser_UsersLikedId",
                table: "RecipeUser",
                column: "UsersLikedId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecipeUser");
        }
    }
}
