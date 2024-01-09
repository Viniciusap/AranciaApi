using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Arancia_Api.Migrations
{
    public partial class DesenvolvedoreProjeto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DesenvolvedorId",
                table: "Projeto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Projeto_DesenvolvedorId",
                table: "Projeto",
                column: "DesenvolvedorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projeto_Desenvolvedor_DesenvolvedorId",
                table: "Projeto",
                column: "DesenvolvedorId",
                principalTable: "Desenvolvedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projeto_Desenvolvedor_DesenvolvedorId",
                table: "Projeto");

            migrationBuilder.DropIndex(
                name: "IX_Projeto_DesenvolvedorId",
                table: "Projeto");

            migrationBuilder.DropColumn(
                name: "DesenvolvedorId",
                table: "Projeto");
        }
    }
}
