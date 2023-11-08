using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PurpleBuzz_homework.Migrations
{
    public partial class nameChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "CategoryValues");

            migrationBuilder.DropColumn(
                name: "ValuesId",
                table: "CategoryValues");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "CategoryValues",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ValuesId",
                table: "CategoryValues",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
