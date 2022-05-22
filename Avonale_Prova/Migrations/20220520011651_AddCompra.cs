using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Avonale_Prova.Migrations
{
    public partial class AddCompra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cartao",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titular = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CartaoCredito = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    data_expiracao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bandeira = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cvv = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cartao", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Compras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    produto_id = table.Column<int>(type: "int", nullable: false),
                    qtde_comprada = table.Column<int>(type: "int", nullable: false),
                    cartaoid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Compras_Cartao_cartaoid",
                        column: x => x.cartaoid,
                        principalTable: "Cartao",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Compras_cartaoid",
                table: "Compras",
                column: "cartaoid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Compras");

            migrationBuilder.DropTable(
                name: "Cartao");
        }
    }
}
