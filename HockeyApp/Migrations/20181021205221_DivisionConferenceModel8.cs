using Microsoft.EntityFrameworkCore.Migrations;

namespace HockeyApp.Migrations
{
    public partial class DivisionConferenceModel8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DivisionID",
                table: "Team",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Team_DivisionID",
                table: "Team",
                column: "DivisionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Team_Division_DivisionID",
                table: "Team",
                column: "DivisionID",
                principalTable: "Division",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Team_Division_DivisionID",
                table: "Team");

            migrationBuilder.DropIndex(
                name: "IX_Team_DivisionID",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "DivisionID",
                table: "Team");
        }
    }
}
