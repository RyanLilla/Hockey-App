using Microsoft.EntityFrameworkCore.Migrations;

namespace HockeyApp.Migrations
{
    public partial class AddConferenceActual : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConferenceID",
                table: "Team",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Team_ConferenceID",
                table: "Team",
                column: "ConferenceID");

            migrationBuilder.AddForeignKey(
                name: "FK_Team_Conference_ConferenceID",
                table: "Team",
                column: "ConferenceID",
                principalTable: "Conference",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Team_Conference_ConferenceID",
                table: "Team");

            migrationBuilder.DropIndex(
                name: "IX_Team_ConferenceID",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "ConferenceID",
                table: "Team");
        }
    }
}
