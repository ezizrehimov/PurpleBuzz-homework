using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PurpleBuzz_homework.Migrations
{
    public partial class ProjectWorkCategoriesandProjectWorkValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectWorkCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectWorkCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectWorkValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectWorkValues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectWorkCategoriesProjectWorkValues",
                columns: table => new
                {
                    WorkCategoriesId = table.Column<int>(type: "int", nullable: false),
                    WorkValuesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectWorkCategoriesProjectWorkValues", x => new { x.WorkCategoriesId, x.WorkValuesId });
                    table.ForeignKey(
                        name: "FK_ProjectWorkCategoriesProjectWorkValues_ProjectWorkCategories_WorkCategoriesId",
                        column: x => x.WorkCategoriesId,
                        principalTable: "ProjectWorkCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectWorkCategoriesProjectWorkValues_ProjectWorkValues_WorkValuesId",
                        column: x => x.WorkValuesId,
                        principalTable: "ProjectWorkValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectWorkCategoriesProjectWorkValues_WorkValuesId",
                table: "ProjectWorkCategoriesProjectWorkValues",
                column: "WorkValuesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectWorkCategoriesProjectWorkValues");

            migrationBuilder.DropTable(
                name: "ProjectWorkCategories");

            migrationBuilder.DropTable(
                name: "ProjectWorkValues");
        }
    }
}
