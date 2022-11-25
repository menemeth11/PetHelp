using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetHelp.Server.Migrations
{
    public partial class update_zwierz_model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zwierzeta_ListaHodowli_HodowlaId",
                table: "Zwierzeta");

            migrationBuilder.AlterColumn<int>(
                name: "HodowlaId",
                table: "Zwierzeta",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Zwierzeta_ListaHodowli_HodowlaId",
                table: "Zwierzeta",
                column: "HodowlaId",
                principalTable: "ListaHodowli",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zwierzeta_ListaHodowli_HodowlaId",
                table: "Zwierzeta");

            migrationBuilder.AlterColumn<int>(
                name: "HodowlaId",
                table: "Zwierzeta",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Zwierzeta_ListaHodowli_HodowlaId",
                table: "Zwierzeta",
                column: "HodowlaId",
                principalTable: "ListaHodowli",
                principalColumn: "id");
        }
    }
}
