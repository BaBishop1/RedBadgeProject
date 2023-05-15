using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.Data.Migrations
{
    /// <inheritdoc />
    public partial class ReviewChangeFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReviewText",
                table: "Ratings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReviewText",
                table: "Ratings");
        }
    }
}
