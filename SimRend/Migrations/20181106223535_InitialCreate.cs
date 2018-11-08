using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimRend.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Solicitud",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FechaActual = table.Column<DateTime>(nullable: false),
                    Monto = table.Column<int>(nullable: false),
                    NombreEvento = table.Column<string>(nullable: true),
                    FechaEvento = table.Column<DateTime>(nullable: false),
                    LugarEvento = table.Column<string>(nullable: true),
                    Responsable = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitud", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Solicitud");
        }
    }
}
