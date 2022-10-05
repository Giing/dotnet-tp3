using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP3Rest.Migrations
{
    public partial class CreationBDSeries_update_name_field : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "utl_ latitude",
                schema: "public",
                table: "t_e_utilisateur_utl",
                newName: "utl_latitude");

            migrationBuilder.AddColumn<string>(
                name: "utl_nom",
                schema: "public",
                table: "t_e_utilisateur_utl",
                type: "varchar(50)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "utl_nom",
                schema: "public",
                table: "t_e_utilisateur_utl");

            migrationBuilder.RenameColumn(
                name: "utl_latitude",
                schema: "public",
                table: "t_e_utilisateur_utl",
                newName: "utl_ latitude");
        }
    }
}
