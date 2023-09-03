using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Elements.Persistence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title_Value = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    ImageName_Value = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Disclaimers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Message_Value = table.Column<string>(type: "TEXT", nullable: false),
                    HasDisplayed = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disclaimers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reminders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title_Value = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Recurrence = table.Column<int>(type: "INTEGER", nullable: false),
                    Season = table.Column<int>(type: "INTEGER", nullable: false),
                    PlatformId_Value = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    IsEnabled = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reminders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Updates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Updates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Header_Value = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Text_Value = table.Column<string>(type: "TEXT", nullable: false),
                    Order_Value = table.Column<int>(type: "INTEGER", nullable: false),
                    ArticleId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sections_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_Id",
                table: "Articles",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Disclaimers_Id",
                table: "Disclaimers",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Reminders_Id",
                table: "Reminders",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_ArticleId",
                table: "Sections",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_Id",
                table: "Sections",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Updates_Id",
                table: "Updates",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Updates_Value",
                table: "Updates",
                column: "Value");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Disclaimers");

            migrationBuilder.DropTable(
                name: "Reminders");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "Updates");

            migrationBuilder.DropTable(
                name: "Articles");
        }
    }
}
