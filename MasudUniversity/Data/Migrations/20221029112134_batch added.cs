using Microsoft.EntityFrameworkCore.Migrations;

namespace MasudUniversity.Data.Migrations
{
    public partial class batchadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Batch",
                table: "Student",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Batch",
                table: "Student");
        }
    }
}
