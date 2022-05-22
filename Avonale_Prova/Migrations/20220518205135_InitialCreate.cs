using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Avonale_Prova.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    valor_unitario = table.Column<float>(type: "real", nullable: false),
                    qtde_estoque = table.Column<int>(type: "int", nullable: false),
                    Ultima_venda = table.Column<DateTime>(type: "datetime2", nullable: true),
                    valor_ultima_venda = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produtos");
        }
    }
}
