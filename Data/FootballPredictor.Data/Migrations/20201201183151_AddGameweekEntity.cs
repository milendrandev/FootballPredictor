namespace FootballPredictor.Data.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddGameweekEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropColumn(
                name: "GameWeek",
                table: "Matches");

            migrationBuilder.AddColumn<int>(
                name: "GameweekId",
                table: "Predictions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsPredictedAwayGoals",
                table: "Predictions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPredictedHomeGoals",
                table: "Predictions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPredictedResult",
                table: "Predictions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "GameweekId",
                table: "Matches",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Gameweeks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gameweeks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameweekUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    GameweekId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    UserPoints = table.Column<int>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameweekUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameweekUsers_Gameweeks_GameweekId",
                        column: x => x.GameweekId,
                        principalTable: "Gameweeks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GameweekUsers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Predictions_GameweekId",
                table: "Predictions",
                column: "GameweekId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_GameweekId",
                table: "Matches",
                column: "GameweekId");

            migrationBuilder.CreateIndex(
                name: "IX_Gameweeks_IsDeleted",
                table: "Gameweeks",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_GameweekUsers_GameweekId",
                table: "GameweekUsers",
                column: "GameweekId");

            migrationBuilder.CreateIndex(
                name: "IX_GameweekUsers_IsDeleted",
                table: "GameweekUsers",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_GameweekUsers_UserId",
                table: "GameweekUsers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Gameweeks_GameweekId",
                table: "Matches",
                column: "GameweekId",
                principalTable: "Gameweeks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Predictions_Gameweeks_GameweekId",
                table: "Predictions",
                column: "GameweekId",
                principalTable: "Gameweeks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Gameweeks_GameweekId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Predictions_Gameweeks_GameweekId",
                table: "Predictions");

            migrationBuilder.DropTable(
                name: "GameweekUsers");

            migrationBuilder.DropTable(
                name: "Gameweeks");

            migrationBuilder.DropIndex(
                name: "IX_Predictions_GameweekId",
                table: "Predictions");

            migrationBuilder.DropIndex(
                name: "IX_Matches_GameweekId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "GameweekId",
                table: "Predictions");

            migrationBuilder.DropColumn(
                name: "IsPredictedAwayGoals",
                table: "Predictions");

            migrationBuilder.DropColumn(
                name: "IsPredictedHomeGoals",
                table: "Predictions");

            migrationBuilder.DropColumn(
                name: "IsPredictedResult",
                table: "Predictions");

            migrationBuilder.DropColumn(
                name: "GameweekId",
                table: "Matches");

            migrationBuilder.AddColumn<int>(
                name: "GameWeek",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Settings_IsDeleted",
                table: "Settings",
                column: "IsDeleted");
        }
    }
}
