using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCommerceSiteExample.Migrations
{
    public partial class AddedGameColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Device",
                table: "Games",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Region",
                table: "Games",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Device",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Region",
                table: "Games");
        }
    }
}
