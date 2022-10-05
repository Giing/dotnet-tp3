using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP3Rest.Migrations
{
    public partial class CreationBDSeries_update_nullable_fields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Utilisateur",
                schema: "public",
                table: "t_j_notation_not",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "Serie",
                schema: "public",
                table: "t_j_notation_not",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Utilisateur",
                schema: "public",
                table: "t_j_notation_not",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Serie",
                schema: "public",
                table: "t_j_notation_not",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);
        }
    }
}
