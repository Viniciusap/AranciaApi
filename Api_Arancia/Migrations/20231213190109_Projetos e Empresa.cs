using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api_Arancia.Migrations
{
    public partial class ProjetoseEmpresa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Projetos",
                table: "Projetos");

            migrationBuilder.DropIndex(
                name: "IX_Projetos_EmpresaId",
                table: "Projetos");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Projetos",
                newName: "DesenvolvedoresId");

            migrationBuilder.AlterColumn<int>(
                name: "DesenvolvedoresId",
                table: "Projetos",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Projetos",
                table: "Projetos",
                columns: new[] { "EmpresaId", "DesenvolvedoresId" });

            migrationBuilder.CreateIndex(
                name: "IX_Projetos_DesenvolvedoresId",
                table: "Projetos",
                column: "DesenvolvedoresId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projetos_Desenvolvedores_DesenvolvedoresId",
                table: "Projetos",
                column: "DesenvolvedoresId",
                principalTable: "Desenvolvedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projetos_Desenvolvedores_DesenvolvedoresId",
                table: "Projetos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Projetos",
                table: "Projetos");

            migrationBuilder.DropIndex(
                name: "IX_Projetos_DesenvolvedoresId",
                table: "Projetos");

            migrationBuilder.RenameColumn(
                name: "DesenvolvedoresId",
                table: "Projetos",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Projetos",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Projetos",
                table: "Projetos",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Projetos_EmpresaId",
                table: "Projetos",
                column: "EmpresaId");
        }
    }
}
