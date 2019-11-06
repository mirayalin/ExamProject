using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetWebCore.Migrations
{
    public partial class newtableeeee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "QuestionAnswer",
                table: "questions",
                newName: "TrueAnswer");

            migrationBuilder.AddColumn<string>(
                name: "QuestionAnswerA",
                table: "questions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "QuestionAnswerB",
                table: "questions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "QuestionAnswerC",
                table: "questions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "QuestionAnswerD",
                table: "questions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuestionAnswerA",
                table: "questions");

            migrationBuilder.DropColumn(
                name: "QuestionAnswerB",
                table: "questions");

            migrationBuilder.DropColumn(
                name: "QuestionAnswerC",
                table: "questions");

            migrationBuilder.DropColumn(
                name: "QuestionAnswerD",
                table: "questions");

            migrationBuilder.RenameColumn(
                name: "TrueAnswer",
                table: "questions",
                newName: "QuestionAnswer");
        }
    }
}
