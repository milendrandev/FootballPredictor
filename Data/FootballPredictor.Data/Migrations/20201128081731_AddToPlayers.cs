using Microsoft.EntityFrameworkCore.Migrations;

namespace FootballPredictor.Data.Migrations
{
    public partial class AddToPlayers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MatchesPlayed",
                table: "Players",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ScoredGoals",
                table: "Players",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MatchesPlayed",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "ScoredGoals",
                table: "Players");
        }
    }
}
