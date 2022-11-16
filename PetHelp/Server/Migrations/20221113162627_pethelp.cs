using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetHelp.Server.Migrations
{
    public partial class pethelp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "gatunekID",
                table: "rasy_psow",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "gatunekID",
                table: "rasy_psow");
        }
    }
}
