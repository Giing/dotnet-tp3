using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TP3Rest.Migrations
{
    public partial class CreationBDSeries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "t_e_serie_ser",
                schema: "public",
                columns: table => new
                {
                    ser_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ser_titre = table.Column<string>(type: "varchar(100)", nullable: false),
                    ser_resume = table.Column<string>(type: "text", nullable: true),
                    ser_nbsaisons = table.Column<int>(type: "integer", nullable: true),
                    ser_nbepisodes = table.Column<int>(type: "integer", nullable: true),
                    ser_anneecreation = table.Column<int>(type: "integer", nullable: true),
                    ser_network = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_serie_ser", x => x.ser_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_utilisateur_utl",
                schema: "public",
                columns: table => new
                {
                    utl_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    utl_prenom = table.Column<string>(type: "varchar(50)", nullable: true),
                    utl_mobile = table.Column<string>(type: "char(10)", nullable: true),
                    utl_mail = table.Column<string>(type: "varchar(100)", nullable: true),
                    utl_pwd = table.Column<string>(type: "varchar(64)", nullable: true),
                    utl_rue = table.Column<string>(type: "varchar(200)", nullable: true),
                    utl_codepostal = table.Column<string>(type: "char(5)", nullable: true),
                    utl_ville = table.Column<string>(type: "varchar(50)", nullable: true),
                    utl_pays = table.Column<string>(type: "varchar(50)", nullable: true),
                    utl_latitude = table.Column<float>(name: "utl_ latitude", type: "real", nullable: true),
                    utl_longitude = table.Column<float>(type: "real", nullable: true),
                    utl_datecreation = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "current_date")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_utilisateur_utl", x => x.utl_id);
                });

            migrationBuilder.CreateTable(
                name: "t_j_notation_not",
                schema: "public",
                columns: table => new
                {
                    not_utl_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    not_ser_id = table.Column<int>(type: "integer", nullable: false),
                    not_note = table.Column<int>(type: "integer", nullable: false),
                    Serie = table.Column<int>(type: "integer", nullable: false),
                    Utilisateur = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_j_notation_not", x => x.not_utl_id);
                    table.CheckConstraint("CK_not_note", "0 <= not_note AND not_note <= 5");
                    table.ForeignKey(
                        name: "fk_note_ser",
                        column: x => x.Serie,
                        principalSchema: "public",
                        principalTable: "t_e_serie_ser",
                        principalColumn: "ser_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_note_utl",
                        column: x => x.Utilisateur,
                        principalSchema: "public",
                        principalTable: "t_e_utilisateur_utl",
                        principalColumn: "utl_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_t_e_utilisateur_utl_utl_mail",
                schema: "public",
                table: "t_e_utilisateur_utl",
                column: "utl_mail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_t_j_notation_not_Serie",
                schema: "public",
                table: "t_j_notation_not",
                column: "Serie");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_notation_not_Utilisateur",
                schema: "public",
                table: "t_j_notation_not",
                column: "Utilisateur");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_j_notation_not",
                schema: "public");

            migrationBuilder.DropTable(
                name: "t_e_serie_ser",
                schema: "public");

            migrationBuilder.DropTable(
                name: "t_e_utilisateur_utl",
                schema: "public");
        }
    }
}
