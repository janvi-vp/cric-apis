using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cric_api.Models.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMatchSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AwayTeamCaptainId",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AwayTeamWicketkepperId",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HomeTeamCaptainId",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HomeTeamWicketkepperId",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Matches_AwayTeamCaptainId",
                table: "Matches",
                column: "AwayTeamCaptainId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_AwayTeamWicketkepperId",
                table: "Matches",
                column: "AwayTeamWicketkepperId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_HomeTeamCaptainId",
                table: "Matches",
                column: "HomeTeamCaptainId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_HomeTeamWicketkepperId",
                table: "Matches",
                column: "HomeTeamWicketkepperId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Players_AwayTeamCaptainId",
                table: "Matches",
                column: "AwayTeamCaptainId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Players_AwayTeamWicketkepperId",
                table: "Matches",
                column: "AwayTeamWicketkepperId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Players_HomeTeamCaptainId",
                table: "Matches",
                column: "HomeTeamCaptainId",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Players_AwayTeamCaptainId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Players_AwayTeamWicketkepperId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Players_HomeTeamCaptainId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Players_HomeTeamWicketkepperId",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_AwayTeamCaptainId",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_AwayTeamWicketkepperId",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_HomeTeamCaptainId",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_HomeTeamWicketkepperId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "AwayTeamCaptainId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "AwayTeamWicketkepperId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "HomeTeamCaptainId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "HomeTeamWicketkepperId",
                table: "Matches");
        }
    }
}
