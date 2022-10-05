using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TP3Rest.Migrations
{
    public partial class CreationBDSeries_update_foreign_keys_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_t_j_notation_not",
                schema: "public",
                table: "t_j_notation_not");

            migrationBuilder.AlterColumn<int>(
                name: "utl_id",
                schema: "public",
                table: "t_j_notation_not",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_t_j_notation_not",
                schema: "public",
                table: "t_j_notation_not",
                columns: new[] { "ser_id", "utl_id" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_t_j_notation_not",
                schema: "public",
                table: "t_j_notation_not");

            migrationBuilder.AlterColumn<int>(
                name: "utl_id",
                schema: "public",
                table: "t_j_notation_not",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_t_j_notation_not",
                schema: "public",
                table: "t_j_notation_not",
                column: "utl_id");
        }
    }
}
