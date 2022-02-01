using Microsoft.EntityFrameworkCore.Migrations;

namespace Formula1_DAW.Migrations
{
    public partial class SponsorManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sponsor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sponsor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SponsorTeam",
                columns: table => new
                {
                    IdSponsor = table.Column<int>(type: "int", nullable: false),
                    IdTeam = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SponsorTeam", x => new { x.IdSponsor, x.IdTeam });
                    table.ForeignKey(
                        name: "FK_SponsorTeam_Sponsor_IdSponsor",
                        column: x => x.IdSponsor,
                        principalTable: "Sponsor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SponsorTeam_Team_IdTeam",
                        column: x => x.IdTeam,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SponsorTeam_IdTeam",
                table: "SponsorTeam",
                column: "IdTeam");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SponsorTeam");

            migrationBuilder.DropTable(
                name: "Sponsor");
        }
    }
}
