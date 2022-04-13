using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eSportSchool.Migrations
{
    public partial class currencies2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                schema: "eSportSchool",
                table: "Currencies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "eSportSchool",
                table: "Currencies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "eSportSchool",
                table: "Currencies",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                schema: "eSportSchool",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "eSportSchool",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "eSportSchool",
                table: "Currencies");
        }
    }
}
