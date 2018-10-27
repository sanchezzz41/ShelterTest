using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shelter.Web.Migrations
{
    public partial class AddCommentsAndQuest1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Questionnaires",
                columns: table => new
                {
                    QuestionnaireGuid = table.Column<Guid>(nullable: false),
                    UserGuid = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Race = table.Column<string>(nullable: false),
                    Sex = table.Column<string>(nullable: false),
                    Old = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Vaccination = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questionnaires", x => x.QuestionnaireGuid);
                    table.ForeignKey(
                        name: "FK_Questionnaires_Users_UserGuid",
                        column: x => x.UserGuid,
                        principalTable: "Users",
                        principalColumn: "UserGuid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentGuid = table.Column<Guid>(nullable: false),
                    QuestionnaireGuid = table.Column<Guid>(nullable: false),
                    UserGuid = table.Column<Guid>(nullable: false),
                    Text = table.Column<string>(maxLength: 500, nullable: false),
                    CratedDate = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentGuid);
                    table.ForeignKey(
                        name: "FK_Comments_Questionnaires_QuestionnaireGuid",
                        column: x => x.QuestionnaireGuid,
                        principalTable: "Questionnaires",
                        principalColumn: "QuestionnaireGuid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserGuid",
                        column: x => x.UserGuid,
                        principalTable: "Users",
                        principalColumn: "UserGuid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_QuestionnaireGuid",
                table: "Comments",
                column: "QuestionnaireGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserGuid",
                table: "Comments",
                column: "UserGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Questionnaires_UserGuid",
                table: "Questionnaires",
                column: "UserGuid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Questionnaires");
        }
    }
}
