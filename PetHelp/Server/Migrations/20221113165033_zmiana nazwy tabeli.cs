using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetHelp.Server.Migrations
{
    public partial class zmiananazwytabeli : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zwierzeta_rasy_psow_rasy_psowId",
                table: "Zwierzeta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_rasy_psow",
                table: "rasy_psow");

            migrationBuilder.RenameTable(
                name: "rasy_psow",
                newName: "Rasy");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rasy",
                table: "Rasy",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Zwierzeta_Rasy_rasy_psowId",
                table: "Zwierzeta",
                column: "rasy_psowId",
                principalTable: "Rasy",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zwierzeta_Rasy_rasy_psowId",
                table: "Zwierzeta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rasy",
                table: "Rasy");

            migrationBuilder.RenameTable(
                name: "Rasy",
                newName: "rasy_psow");

            migrationBuilder.AddPrimaryKey(
                name: "PK_rasy_psow",
                table: "rasy_psow",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Zwierzeta_rasy_psow_rasy_psowId",
                table: "Zwierzeta",
                column: "rasy_psowId",
                principalTable: "rasy_psow",
                principalColumn: "Id");
        }
    }
}
