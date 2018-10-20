using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HockeyApp.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coach",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    HireDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coach", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CoachID = table.Column<int>(nullable: true),
                    TeamName = table.Column<string>(nullable: true),
                    TeamLocation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Team_Coach_CoachID",
                        column: x => x.CoachID,
                        principalTable: "Coach",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CoachID = table.Column<int>(nullable: false),
                    TeamID = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Position = table.Column<int>(nullable: true),
                    DraftDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Player_Coach_CoachID",
                        column: x => x.CoachID,
                        principalTable: "Coach",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Player_Team_TeamID",
                        column: x => x.TeamID,
                        principalTable: "Team",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Player_CoachID",
                table: "Player",
                column: "CoachID");

            migrationBuilder.CreateIndex(
                name: "IX_Player_TeamID",
                table: "Player",
                column: "TeamID");

            migrationBuilder.CreateIndex(
                name: "IX_Team_CoachID",
                table: "Team",
                column: "CoachID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "Coach");
        }
    }
}
