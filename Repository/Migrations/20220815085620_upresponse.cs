using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class upresponse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_QuestionOptions_QuestionOptionId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Responses_ResponsesId",
                table: "Answers");

            migrationBuilder.DropIndex(
                name: "IX_Answers_ResponsesId",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "Label1",
                table: "QuestionOptions");

            migrationBuilder.DropColumn(
                name: "Label2",
                table: "QuestionOptions");

            migrationBuilder.DropColumn(
                name: "Label3",
                table: "QuestionOptions");

            migrationBuilder.DropColumn(
                name: "Label4",
                table: "QuestionOptions");

            migrationBuilder.RenameColumn(
                name: "Label5",
                table: "QuestionOptions",
                newName: "Label");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Responses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Responses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "SubmittedDate",
                table: "Responses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<int>(
                name: "QuestionOptionId",
                table: "Answers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ResponseId",
                table: "Answers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Answers_ResponseId",
                table: "Answers",
                column: "ResponseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_QuestionOptions_QuestionOptionId",
                table: "Answers",
                column: "QuestionOptionId",
                principalTable: "QuestionOptions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Responses_ResponseId",
                table: "Answers",
                column: "ResponseId",
                principalTable: "Responses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_QuestionOptions_QuestionOptionId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Responses_ResponseId",
                table: "Answers");

            migrationBuilder.DropIndex(
                name: "IX_Answers_ResponseId",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Responses");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Responses");

            migrationBuilder.DropColumn(
                name: "SubmittedDate",
                table: "Responses");

            migrationBuilder.DropColumn(
                name: "ResponseId",
                table: "Answers");

            migrationBuilder.RenameColumn(
                name: "Label",
                table: "QuestionOptions",
                newName: "Label5");

            migrationBuilder.AddColumn<string>(
                name: "Label1",
                table: "QuestionOptions",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Label2",
                table: "QuestionOptions",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Label3",
                table: "QuestionOptions",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Label4",
                table: "QuestionOptions",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "QuestionOptionId",
                table: "Answers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Answers_ResponsesId",
                table: "Answers",
                column: "ResponsesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_QuestionOptions_QuestionOptionId",
                table: "Answers",
                column: "QuestionOptionId",
                principalTable: "QuestionOptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Responses_ResponsesId",
                table: "Answers",
                column: "ResponsesId",
                principalTable: "Responses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
