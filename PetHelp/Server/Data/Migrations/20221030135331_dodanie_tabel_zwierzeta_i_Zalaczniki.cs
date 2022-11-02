using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetHelp.Server.Data.Migrations
{
    public partial class dodanie_tabel_zwierzeta_i_Zalaczniki : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Zwierzeta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gatunek = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rasa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Umaszczenie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataUrodzenia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataDodania = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Kastracja = table.Column<bool>(type: "bit", nullable: false),
                    Waga_Pomiar = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Waga_Wartosc = table.Column<float>(type: "real", nullable: true),
                    Info_Dodatkowe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Info_Schorzenia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Info_Choroby = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Szczepienie_Wscieklizna_Status = table.Column<bool>(type: "bit", nullable: false),
                    Szczepienie_Wscieklizna_Data = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Szczepienie_Wscieklizna_NastepnyTermin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HodowlaId = table.Column<int>(type: "int", nullable: true),
                    WlascicielId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zwierzeta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zwierzeta_AspNetUsers_WlascicielId",
                        column: x => x.WlascicielId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zwierzeta_ListaHodowli_HodowlaId",
                        column: x => x.HodowlaId,
                        principalTable: "ListaHodowli",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Zalaczniks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Zdjecie_MIME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Zdjecie_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Zdjecie_Data = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ZwierzeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zalaczniks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zalaczniks_Zwierzeta_ZwierzeId",
                        column: x => x.ZwierzeId,
                        principalTable: "Zwierzeta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Zalaczniks_ZwierzeId",
                table: "Zalaczniks",
                column: "ZwierzeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Zwierzeta_HodowlaId",
                table: "Zwierzeta",
                column: "HodowlaId");

            migrationBuilder.CreateIndex(
                name: "IX_Zwierzeta_WlascicielId",
                table: "Zwierzeta",
                column: "WlascicielId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Zalaczniks");

            migrationBuilder.DropTable(
                name: "Zwierzeta");
        }
    }
}
