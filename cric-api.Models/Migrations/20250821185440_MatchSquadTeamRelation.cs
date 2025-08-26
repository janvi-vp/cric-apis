using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cric_api.Models.Migrations
{
    /// <inheritdoc />
    public partial class MatchSquadTeamRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Squads_TeamId",
                table: "Squads",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Squads_Teams_TeamId",
                table: "Squads",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Squads_Teams_TeamId",
                table: "Squads");

            migrationBuilder.DropIndex(
                name: "IX_Squads_TeamId",
                table: "Squads");
        }
    }
}
