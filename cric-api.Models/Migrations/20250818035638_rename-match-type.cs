using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cric_api.Models.Migrations
{
    /// <inheritdoc />
    public partial class renamematchtype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TypeOfMatch",
                table: "Matches",
                newName: "MatchType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MatchType",
                table: "Matches",
                newName: "TypeOfMatch");
        }
    }
}
