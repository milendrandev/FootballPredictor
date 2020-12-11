using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FootballPredictor.Data.Migrations
{
    public partial class MiniLigueEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MiniLigues",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    MiniLigueType = table.Column<int>(nullable: false),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MiniLigues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MiniLeagueUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    MiniLigueId = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MiniLeagueUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MiniLeagueUsers_MiniLigues_MiniLigueId",
                        column: x => x.MiniLigueId,
                        principalTable: "MiniLigues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MiniLeagueUsers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MiniLeagueUsers_IsDeleted",
                table: "MiniLeagueUsers",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_MiniLeagueUsers_MiniLigueId",
                table: "MiniLeagueUsers",
                column: "MiniLigueId");

            migrationBuilder.CreateIndex(
                name: "IX_MiniLeagueUsers_UserId",
                table: "MiniLeagueUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MiniLigues_IsDeleted",
                table: "MiniLigues",
                column: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MiniLeagueUsers");

            migrationBuilder.DropTable(
                name: "MiniLigues");
        }
    }
}
