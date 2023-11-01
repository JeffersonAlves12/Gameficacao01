using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gameficacao01.API.Migrations
{
    /// <inheritdoc />
    public partial class new_context4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipes_Projetos_ProjetosId",
                table: "Equipes");

            migrationBuilder.DropIndex(
                name: "IX_Equipes_ProjetosId",
                table: "Equipes");

            migrationBuilder.DropColumn(
                name: "ProjetosId",
                table: "Equipes");

            migrationBuilder.CreateIndex(
                name: "IX_Equipes_ProjetoId",
                table: "Equipes",
                column: "ProjetoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipes_Projetos_ProjetoId",
                table: "Equipes",
                column: "ProjetoId",
                principalTable: "Projetos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipes_Projetos_ProjetoId",
                table: "Equipes");

            migrationBuilder.DropIndex(
                name: "IX_Equipes_ProjetoId",
                table: "Equipes");

            migrationBuilder.AddColumn<int>(
                name: "ProjetosId",
                table: "Equipes",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Equipes_ProjetosId",
                table: "Equipes",
                column: "ProjetosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipes_Projetos_ProjetosId",
                table: "Equipes",
                column: "ProjetosId",
                principalTable: "Projetos",
                principalColumn: "Id");
        }
    }
}
