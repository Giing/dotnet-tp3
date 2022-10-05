using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP3Rest.Migrations
{
    public partial class CreationBDSeries_update_ncp_field : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "utl_codepostal",
                schema: "public",
                table: "t_e_utilisateur_utl",
                newName: "utl_cp");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "utl_cp",
                schema: "public",
                table: "t_e_utilisateur_utl",
                newName: "utl_codepostal");
        }
    }
}
