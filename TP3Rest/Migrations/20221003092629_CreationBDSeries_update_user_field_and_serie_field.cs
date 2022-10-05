using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP3Rest.Migrations
{
    public partial class CreationBDSeries_update_user_field_and_serie_field : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "not_ser_id",
                schema: "public",
                table: "t_j_notation_not",
                newName: "ser_id");

            migrationBuilder.RenameColumn(
                name: "not_utl_id",
                schema: "public",
                table: "t_j_notation_not",
                newName: "utl_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ser_id",
                schema: "public",
                table: "t_j_notation_not",
                newName: "not_ser_id");

            migrationBuilder.RenameColumn(
                name: "utl_id",
                schema: "public",
                table: "t_j_notation_not",
                newName: "not_utl_id");
        }
    }
}
