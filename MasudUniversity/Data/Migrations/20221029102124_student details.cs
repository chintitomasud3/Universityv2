using Microsoft.EntityFrameworkCore.Migrations;

namespace MasudUniversity.Data.Migrations
{
    public partial class studentdetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Student",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MartialStatus",
                table: "Student",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nationality",
                table: "Student",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Religion",
                table: "Student",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "MartialStatus",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "Nationality",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "Religion",
                table: "Student");
        }
    }
}
