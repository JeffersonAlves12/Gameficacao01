using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gameficacao01.API.Migrations
{
    /// <inheritdoc />
    public partial class new_context2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sprints_Projetos_ProjetoId",
                table: "Sprints");

            migrationBuilder.DropForeignKey(
                name: "FK_Tarefas_Projetos_ProjetoId",
                table: "Tarefas");

            migrationBuilder.DropIndex(
                name: "IX_Sprints_ProjetoId",
                table: "Sprints");

            migrationBuilder.DropColumn(
                name: "ProjetoId",
                table: "Sprints");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefas_Projetos_ProjetoId",
                table: "Tarefas",
                column: "ProjetoId",
                principalTable: "Projetos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarefas_Projetos_ProjetoId",
                table: "Tarefas");

            migrationBuilder.AddColumn<int>(
                name: "ProjetoId",
                table: "Sprints",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sprints_ProjetoId",
                table: "Sprints",
                column: "ProjetoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sprints_Projetos_ProjetoId",
                table: "Sprints",
                column: "ProjetoId",
                principalTable: "Projetos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefas_Projetos_ProjetoId",
                table: "Tarefas",
                column: "ProjetoId",
                principalTable: "Projetos",
                principalColumn: "Id");
        }
    }
}
