using Microsoft.EntityFrameworkCore.Migrations;

namespace MasudUniversity.Data.Migrations
{
    public partial class delte : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "check",
                table: "Student");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "check",
                table: "Student",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
