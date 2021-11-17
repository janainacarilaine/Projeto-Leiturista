using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class criacaotabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tbl_leituristas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    matricula = table.Column<long>(type: "bigint", nullable: false),
                    nome = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ativo = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_leituristas", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tbl_ocorrencias",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    descricao = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    permite_leitura = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    valor = table.Column<decimal>(type: "decimal(10,3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_ocorrencias", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tbl_usuarios",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    senha = table.Column<string>(type: "VARCHAR(32)", maxLength: 32, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    funcao = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_usuarios", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tbl_leituras",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    codigo_cliente = table.Column<long>(type: "bigint", nullable: false),
                    leitura_anterior = table.Column<long>(type: "bigint", nullable: false),
                    leitura_atual = table.Column<long>(type: "bigint", nullable: true),
                    id_leiturista = table.Column<long>(name: "id_ leiturista", type: "bigint", nullable: false),
                    id_ocorrencia = table.Column<long>(type: "bigint", nullable: false),
                    latitude = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    longitude = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    data_leitura = table.Column<DateTime>(type: "datetime(0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_leituras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_leituras_tbl_leituristas_id_ leiturista",
                        column: x => x.id_leiturista,
                        principalTable: "tbl_leituristas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_leituras_tbl_ocorrencias_id_ocorrencia",
                        column: x => x.id_ocorrencia,
                        principalTable: "tbl_ocorrencias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_leituras_id_ leiturista",
                table: "tbl_leituras",
                column: "id_ leiturista");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_leituras_id_ocorrencia",
                table: "tbl_leituras",
                column: "id_ocorrencia");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_leituras");

            migrationBuilder.DropTable(
                name: "tbl_usuarios");

            migrationBuilder.DropTable(
                name: "tbl_leituristas");

            migrationBuilder.DropTable(
                name: "tbl_ocorrencias");
        }
    }
}
