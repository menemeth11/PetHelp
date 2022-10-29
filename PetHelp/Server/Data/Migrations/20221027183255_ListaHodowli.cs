using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetHelp.Server.Data.Migrations
{
    public partial class ListaHodowli : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ListaHodowli",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WlascicielID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListaHodowli", x => x.id);
                    table.ForeignKey(
                        name: "FK_ListaHodowli_AspNetUsers_WlascicielID",
                        column: x => x.WlascicielID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ListaHodowli_WlascicielID",
                table: "ListaHodowli",
                column: "WlascicielID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListaHodowli");
        }
    }
}
