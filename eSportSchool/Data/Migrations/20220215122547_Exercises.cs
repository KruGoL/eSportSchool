using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eSportSchool.Data.Migrations
{
    public partial class Exercises : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "TrainingData",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "TrainingData",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ExerciseId",
                table: "TrainingData",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExerciseTitle",
                table: "TrainingData",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "TrainingData");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "TrainingData");

            migrationBuilder.DropColumn(
                name: "ExerciseId",
                table: "TrainingData");

            migrationBuilder.DropColumn(
                name: "ExerciseTitle",
                table: "TrainingData");
        }
    }
}
