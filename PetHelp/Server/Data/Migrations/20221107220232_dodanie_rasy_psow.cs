using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetHelp.Server.Data.Migrations
{
    public partial class dodanie_rasy_psow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "rasy_psowId",
                table: "Zwierzeta",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "rasy_psow",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rasy_psow", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Zwierzeta_rasy_psowId",
                table: "Zwierzeta",
                column: "rasy_psowId");

            migrationBuilder.AddForeignKey(
                name: "FK_Zwierzeta_rasy_psow_rasy_psowId",
                table: "Zwierzeta",
                column: "rasy_psowId",
                principalTable: "rasy_psow",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zwierzeta_rasy_psow_rasy_psowId",
                table: "Zwierzeta");

            migrationBuilder.DropTable(
                name: "rasy_psow");

            migrationBuilder.DropIndex(
                name: "IX_Zwierzeta_rasy_psowId",
                table: "Zwierzeta");

            migrationBuilder.DropColumn(
                name: "rasy_psowId",
                table: "Zwierzeta");
        }
    }
}
