using Microsoft.EntityFrameworkCore.Migrations;

namespace LPLMVC.Migrations.LPLTeams
{
    public partial class TeamMigrate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Player7",
                table: "TeamDataModels",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(250)");

            migrationBuilder.AlterColumn<string>(
                name: "Player6",
                table: "TeamDataModels",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(250)");

            migrationBuilder.AlterColumn<string>(
                name: "Player5",
                table: "TeamDataModels",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(250)");

            migrationBuilder.AlterColumn<string>(
                name: "Player4",
                table: "TeamDataModels",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(250)");

            migrationBuilder.AlterColumn<string>(
                name: "Player3",
                table: "TeamDataModels",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(250)");

            migrationBuilder.AlterColumn<string>(
                name: "Player2",
                table: "TeamDataModels",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(250)");

            migrationBuilder.AlterColumn<string>(
                name: "Player1",
                table: "TeamDataModels",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(250)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Player7",
                table: "TeamDataModels",
                type: "varchar(250)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Player6",
                table: "TeamDataModels",
                type: "varchar(250)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Player5",
                table: "TeamDataModels",
                type: "varchar(250)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Player4",
                table: "TeamDataModels",
                type: "varchar(250)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Player3",
                table: "TeamDataModels",
                type: "varchar(250)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Player2",
                table: "TeamDataModels",
                type: "varchar(250)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Player1",
                table: "TeamDataModels",
                type: "varchar(250)",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
