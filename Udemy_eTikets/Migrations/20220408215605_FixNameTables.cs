using Microsoft.EntityFrameworkCore.Migrations;

namespace Udemy_eTikets.Migrations
{
    public partial class FixNameTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfulePictureURL",
                table: "Producers");

            migrationBuilder.DropColumn(
                name: "ProfulePictureURL",
                table: "Actors");

            migrationBuilder.AddColumn<string>(
                name: "ProfilePictureURL",
                table: "Producers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfilePictureURL",
                table: "Actors",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePictureURL",
                table: "Producers");

            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "ProfilePictureURL",
                table: "Actors");

            migrationBuilder.AddColumn<int>(
                name: "ProfulePictureURL",
                table: "Producers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProfulePictureURL",
                table: "Actors",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
