using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PurpleBuzz_homework.Migrations
{
    public partial class CategoryValuesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectWorkCategoriesProjectWorkValues");

            migrationBuilder.CreateTable(
                name: "CategoryValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    workCategoriesId = table.Column<int>(type: "int", nullable: false),
                    ValuesId = table.Column<int>(type: "int", nullable: false),
                    workValuesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryValues_ProjectWorkCategories_workCategoriesId",
                        column: x => x.workCategoriesId,
                        principalTable: "ProjectWorkCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryValues_ProjectWorkValues_workValuesId",
                        column: x => x.workValuesId,
                        principalTable: "ProjectWorkValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryValues_workCategoriesId",
                table: "CategoryValues",
                column: "workCategoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryValues_workValuesId",
                table: "CategoryValues",
                column: "workValuesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryValues");

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
    }
}
