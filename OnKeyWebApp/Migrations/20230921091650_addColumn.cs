using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnKeyWebApp.Migrations
{
    public partial class addColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "MusicClubs",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "MusicClubs");
        }
    }
}
