using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gameficacao01.API.Migrations
{
    /// <inheritdoc />
    public partial class AddEquipeId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Membros_Equipes_EquipedId",
                table: "Membros");

            migrationBuilder.AddColumn<int>(
                name: "EquipeId",
                table: "Projetos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Membros_Equipes_EquipedId",
                table: "Membros",
                column: "EquipedId",
                principalTable: "Equipes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Membros_Equipes_EquipedId",
                table: "Membros");

            migrationBuilder.DropColumn(
                name: "EquipeId",
                table: "Projetos");

            migrationBuilder.AddForeignKey(
                name: "FK_Membros_Equipes_EquipedId",
                table: "Membros",
                column: "EquipedId",
                principalTable: "Equipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
