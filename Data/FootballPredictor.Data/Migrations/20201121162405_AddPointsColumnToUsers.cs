using Microsoft.EntityFrameworkCore.Migrations;

namespace FootballPredictor.Data.Migrations
{
    public partial class AddPointsColumnToUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserPoints",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserPoints",
                table: "AspNetUsers");
        }
    }
}
