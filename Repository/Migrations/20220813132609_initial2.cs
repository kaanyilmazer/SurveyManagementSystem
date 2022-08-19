using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Surveys_Responses_ResponsesId",
                table: "Surveys");

            migrationBuilder.DropIndex(
                name: "IX_Surveys_ResponsesId",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "ResponsesId",
                table: "Surveys");

            migrationBuilder.CreateIndex(
                name: "IX_Responses_SurveyId",
                table: "Responses",
                column: "SurveyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Responses_Surveys_SurveyId",
                table: "Responses",
                column: "SurveyId",
                principalTable: "Surveys",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Responses_Surveys_SurveyId",
                table: "Responses");

            migrationBuilder.DropIndex(
                name: "IX_Responses_SurveyId",
                table: "Responses");

            migrationBuilder.AddColumn<int>(
                name: "ResponsesId",
                table: "Surveys",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_ResponsesId",
                table: "Surveys",
                column: "ResponsesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Surveys_Responses_ResponsesId",
                table: "Surveys",
                column: "ResponsesId",
                principalTable: "Responses",
                principalColumn: "Id");
        }
    }
}
