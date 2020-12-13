using Microsoft.EntityFrameworkCore.Migrations;

namespace FootballPredictor.Data.Migrations
{
    public partial class CreatorToMiniLigue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatorId",
                table: "MiniLigues",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "MiniLigues");
        }
    }
}
