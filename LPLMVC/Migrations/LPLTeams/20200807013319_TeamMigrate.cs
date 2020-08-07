using Microsoft.EntityFrameworkCore.Migrations;

namespace LPLMVC.Migrations.LPLTeams
{
    public partial class TeamMigrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TeamDataModels",
                columns: table => new
                {
                    TeamId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchoolName = table.Column<string>(type: "varchar(250)", nullable: false),
                    Player1 = table.Column<string>(type: "varchar(250)", nullable: false),
                    Player2 = table.Column<string>(type: "varchar(250)", nullable: false),
                    Player3 = table.Column<string>(type: "varchar(250)", nullable: false),
                    Player4 = table.Column<string>(type: "varchar(250)", nullable: false),
                    Player5 = table.Column<string>(type: "varchar(250)", nullable: false),
                    Player6 = table.Column<string>(type: "varchar(250)", nullable: false),
                    Player7 = table.Column<string>(type: "varchar(250)", nullable: false),
                    Wins = table.Column<int>(nullable: false),
                    Games = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamDataModels", x => x.TeamId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeamDataModels");
        }
    }
}
