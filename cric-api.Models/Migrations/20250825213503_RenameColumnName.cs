using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cric_api.Models.Migrations
{
    /// <inheritdoc />
    public partial class RenameColumnName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Players_AwayTeamWicketkepperId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Players_HomeTeamWicketkepperId",
                table: "Matches");

            migrationBuilder.RenameColumn(
                name: "HomeTeamWicketkepperId",
                table: "Matches",
                newName: "HomeTeamWicketkeeperId");

            migrationBuilder.RenameColumn(
                name: "AwayTeamWicketkepperId",
                table: "Matches",
                newName: "AwayTeamWicketkeeperId");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_HomeTeamWicketkepperId",
                table: "Matches",
                newName: "IX_Matches_HomeTeamWicketkeeperId");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_AwayTeamWicketkepperId",
                table: "Matches",
                newName: "IX_Matches_AwayTeamWicketkeeperId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Players_AwayTeamWicketkeeperId",
                table: "Matches",
                column: "AwayTeamWicketkeeperId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Players_HomeTeamWicketkeeperId",
                table: "Matches",
                column: "HomeTeamWicketkeeperId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Players_AwayTeamWicketkeeperId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Players_HomeTeamWicketkeeperId",
                table: "Matches");

            migrationBuilder.RenameColumn(
                name: "HomeTeamWicketkeeperId",
                table: "Matches",
                newName: "HomeTeamWicketkepperId");

            migrationBuilder.RenameColumn(
                name: "AwayTeamWicketkeeperId",
                table: "Matches",
                newName: "AwayTeamWicketkepperId");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_HomeTeamWicketkeeperId",
                table: "Matches",
                newName: "IX_Matches_HomeTeamWicketkepperId");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_AwayTeamWicketkeeperId",
                table: "Matches",
                newName: "IX_Matches_AwayTeamWicketkepperId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Players_AwayTeamWicketkepperId",
                table: "Matches",
                column: "AwayTeamWicketkepperId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Players_HomeTeamWicketkepperId",
                table: "Matches",
                column: "HomeTeamWicketkepperId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
