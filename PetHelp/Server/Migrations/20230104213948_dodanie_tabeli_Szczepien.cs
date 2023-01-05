using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetHelp.Server.Migrations
{
    public partial class dodanie_tabeli_Szczepien : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Szczepienia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SzczepienieType = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataInnyTermin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CzyOdbyte = table.Column<bool>(type: "bit", nullable: false),
                    ZwierzeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Szczepienia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Szczepienia_Zwierzeta_ZwierzeId",
                        column: x => x.ZwierzeId,
                        principalTable: "Zwierzeta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Szczepienia_ZwierzeId",
                table: "Szczepienia",
                column: "ZwierzeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Szczepienia");
        }
    }
}
