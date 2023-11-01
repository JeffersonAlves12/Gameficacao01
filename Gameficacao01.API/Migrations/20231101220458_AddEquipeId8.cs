using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gameficacao01.API.Migrations
{
    /// <inheritdoc />
    public partial class AddEquipeId8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Membros_Equipes_EquipedId",
                table: "Membros");

            migrationBuilder.RenameColumn(
                name: "EquipedId",
                table: "Membros",
                newName: "EquipeId");

            migrationBuilder.RenameIndex(
                name: "IX_Membros_EquipedId",
                table: "Membros",
                newName: "IX_Membros_EquipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Membros_Equipes_EquipeId",
                table: "Membros",
                column: "EquipeId",
                principalTable: "Equipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Membros_Equipes_EquipeId",
                table: "Membros");

            migrationBuilder.RenameColumn(
                name: "EquipeId",
                table: "Membros",
                newName: "EquipedId");

            migrationBuilder.RenameIndex(
                name: "IX_Membros_EquipeId",
                table: "Membros",
                newName: "IX_Membros_EquipedId");

            migrationBuilder.AddForeignKey(
                name: "FK_Membros_Equipes_EquipedId",
                table: "Membros",
                column: "EquipedId",
                principalTable: "Equipes",
                principalColumn: "Id");
        }
    }
}
