using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudyPlanner.Data.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conhecimentos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: false),
                    NivelConhecimentoAtual = table.Column<int>(nullable: false),
                    NivelConhecimentoDesejado = table.Column<int>(nullable: false),
                    Prioridade = table.Column<int>(nullable: false),
                    PlanoAcao = table.Column<string>(type: "varchar(1000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conhecimentos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Conhecimentos");
        }
    }
}
