using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gameficacao01.API.Migrations
{
    /// <inheritdoc />
    public partial class SegundaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Projetos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projetos_ClienteId",
                table: "Projetos",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projetos_Clientes_ClienteId",
                table: "Projetos",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projetos_Clientes_ClienteId",
                table: "Projetos");

            migrationBuilder.DropIndex(
                name: "IX_Projetos_ClienteId",
                table: "Projetos");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Projetos");
        }
    }
}
