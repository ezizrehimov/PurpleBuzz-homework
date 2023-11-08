using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PurpleBuzz_homework.Migrations
{
    public partial class nameChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryValues_ProjectWorkCategories_workCategoriesId",
                table: "CategoryValues");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryValues_ProjectWorkValues_workValuesId",
                table: "CategoryValues");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectWorkValues",
                table: "ProjectWorkValues");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectWorkCategories",
                table: "ProjectWorkCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_projectRecentWorks",
                table: "projectRecentWorks");

            migrationBuilder.RenameTable(
                name: "ProjectWorkValues",
                newName: "WorkValues");

            migrationBuilder.RenameTable(
                name: "ProjectWorkCategories",
                newName: "WorkCategories");

            migrationBuilder.RenameTable(
                name: "projectRecentWorks",
                newName: "RecentWorks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkValues",
                table: "WorkValues",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkCategories",
                table: "WorkCategories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecentWorks",
                table: "RecentWorks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryValues_WorkCategories_workCategoriesId",
                table: "CategoryValues",
                column: "workCategoriesId",
                principalTable: "WorkCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryValues_WorkValues_workValuesId",
                table: "CategoryValues",
                column: "workValuesId",
                principalTable: "WorkValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryValues_WorkCategories_workCategoriesId",
                table: "CategoryValues");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryValues_WorkValues_workValuesId",
                table: "CategoryValues");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkValues",
                table: "WorkValues");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkCategories",
                table: "WorkCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecentWorks",
                table: "RecentWorks");

            migrationBuilder.RenameTable(
                name: "WorkValues",
                newName: "ProjectWorkValues");

            migrationBuilder.RenameTable(
                name: "WorkCategories",
                newName: "ProjectWorkCategories");

            migrationBuilder.RenameTable(
                name: "RecentWorks",
                newName: "projectRecentWorks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectWorkValues",
                table: "ProjectWorkValues",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectWorkCategories",
                table: "ProjectWorkCategories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_projectRecentWorks",
                table: "projectRecentWorks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryValues_ProjectWorkCategories_workCategoriesId",
                table: "CategoryValues",
                column: "workCategoriesId",
                principalTable: "ProjectWorkCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryValues_ProjectWorkValues_workValuesId",
                table: "CategoryValues",
                column: "workValuesId",
                principalTable: "ProjectWorkValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
