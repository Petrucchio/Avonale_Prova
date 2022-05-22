using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Avonale_Prova.Migrations
{
    public partial class AddPagamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compras_Cartao_cartaoid",
                table: "Compras");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cartao",
                table: "Cartao");

            migrationBuilder.RenameTable(
                name: "Cartao",
                newName: "Cartoes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cartoes",
                table: "Cartoes",
                column: "id");

            migrationBuilder.CreateTable(
                name: "Pagamentos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    valor = table.Column<float>(type: "real", nullable: false),
                    estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cartaoid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamentos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Pagamentos_Cartoes_cartaoid",
                        column: x => x.cartaoid,
                        principalTable: "Cartoes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pagamentos_cartaoid",
                table: "Pagamentos",
                column: "cartaoid");

            migrationBuilder.AddForeignKey(
                name: "FK_Compras_Cartoes_cartaoid",
                table: "Compras",
                column: "cartaoid",
                principalTable: "Cartoes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compras_Cartoes_cartaoid",
                table: "Compras");

            migrationBuilder.DropTable(
                name: "Pagamentos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cartoes",
                table: "Cartoes");

            migrationBuilder.RenameTable(
                name: "Cartoes",
                newName: "Cartao");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cartao",
                table: "Cartao",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Compras_Cartao_cartaoid",
                table: "Compras",
                column: "cartaoid",
                principalTable: "Cartao",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
