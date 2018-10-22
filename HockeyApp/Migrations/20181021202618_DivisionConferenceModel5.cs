using Microsoft.EntityFrameworkCore.Migrations;

namespace HockeyApp.Migrations
{
    public partial class DivisionConferenceModel5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Team_Conference_ConferenceID",
            //    table: "Team");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Team_Division_DivisionID",
            //    table: "Team");

            //migrationBuilder.DropTable(
            //    name: "Conference");

            //migrationBuilder.DropTable(
            //    name: "Division");

            //migrationBuilder.DropIndex(
            //    name: "IX_Team_ConferenceID",
            //    table: "Team");

            //migrationBuilder.DropIndex(
            //    name: "IX_Team_DivisionID",
            //    table: "Team");

            //migrationBuilder.DropColumn(
            //    name: "ConferenceID",
            //    table: "Team");

            //migrationBuilder.DropColumn(
            //    name: "DivisionID",
            //    table: "Team");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConferenceID",
                table: "Team",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DivisionID",
                table: "Team",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Conference",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    ConferenceName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conference", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Division",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    DivisionName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Division", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Team_ConferenceID",
                table: "Team",
                column: "ConferenceID");

            migrationBuilder.CreateIndex(
                name: "IX_Team_DivisionID",
                table: "Team",
                column: "DivisionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Team_Conference_ConferenceID",
                table: "Team",
                column: "ConferenceID",
                principalTable: "Conference",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Team_Division_DivisionID",
                table: "Team",
                column: "DivisionID",
                principalTable: "Division",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
