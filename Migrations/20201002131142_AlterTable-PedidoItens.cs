using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EF_Core_API.Migrations
{
    public partial class AlterTablePedidoItens : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderDate",
                table: "PedidosItens");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "PedidosItens");

            migrationBuilder.AddColumn<Guid>(
                name: "IdPedido",
                table: "PedidosItens",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IdProduto",
                table: "PedidosItens",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "Quantidade",
                table: "PedidosItens",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PedidosItens_IdPedido",
                table: "PedidosItens",
                column: "IdPedido");

            migrationBuilder.CreateIndex(
                name: "IX_PedidosItens_IdProduto",
                table: "PedidosItens",
                column: "IdProduto");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidosItens_Pedidos_IdPedido",
                table: "PedidosItens",
                column: "IdPedido",
                principalTable: "Pedidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PedidosItens_Produtos_IdProduto",
                table: "PedidosItens",
                column: "IdProduto",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidosItens_Pedidos_IdPedido",
                table: "PedidosItens");

            migrationBuilder.DropForeignKey(
                name: "FK_PedidosItens_Produtos_IdProduto",
                table: "PedidosItens");

            migrationBuilder.DropIndex(
                name: "IX_PedidosItens_IdPedido",
                table: "PedidosItens");

            migrationBuilder.DropIndex(
                name: "IX_PedidosItens_IdProduto",
                table: "PedidosItens");

            migrationBuilder.DropColumn(
                name: "IdPedido",
                table: "PedidosItens");

            migrationBuilder.DropColumn(
                name: "IdProduto",
                table: "PedidosItens");

            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "PedidosItens");

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderDate",
                table: "PedidosItens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "PedidosItens",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
