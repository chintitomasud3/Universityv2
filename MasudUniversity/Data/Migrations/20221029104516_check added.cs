using Microsoft.EntityFrameworkCore.Migrations;

namespace MasudUniversity.Data.Migrations
{
    public partial class checkadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "check",
                table: "Student",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "check",
                table: "Student");
        }
    }
}
