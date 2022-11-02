using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetHelp.Server.Data.Migrations
{
    public partial class dodaniekolumnzdjecie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Zdjecie_Data",
                table: "Zwierzeta",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<string>(
                name: "Zdjecie_MIME",
                table: "Zwierzeta",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Zdjecie_Name",
                table: "Zwierzeta",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Zdjecie_Data",
                table: "Zwierzeta");

            migrationBuilder.DropColumn(
                name: "Zdjecie_MIME",
                table: "Zwierzeta");

            migrationBuilder.DropColumn(
                name: "Zdjecie_Name",
                table: "Zwierzeta");
        }
    }
}
