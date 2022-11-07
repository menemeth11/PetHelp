using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetHelp.Server.Data.Migrations
{
    public partial class dodanie_rasy_psow_dziala : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zwierzeta_rasy_psow_rasy_psowId",
                table: "Zwierzeta");

            migrationBuilder.AlterColumn<int>(
                name: "rasy_psowId",
                table: "Zwierzeta",
                type: "int",
                nullable: true,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Zwierzeta_rasy_psow_rasy_psowId",
                table: "Zwierzeta",
                column: "rasy_psowId",
                principalTable: "rasy_psow",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zwierzeta_rasy_psow_rasy_psowId",
                table: "Zwierzeta");

            migrationBuilder.AlterColumn<int>(
                name: "rasy_psowId",
                table: "Zwierzeta",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Zwierzeta_rasy_psow_rasy_psowId",
                table: "Zwierzeta",
                column: "rasy_psowId",
                principalTable: "rasy_psow",
                principalColumn: "Id");
        }
    }
}
