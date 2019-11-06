using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetWebCore.Migrations
{
    public partial class newtableee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HeaderId",
                table: "questions",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HeaderId",
                table: "questions");
        }
    }
}
