using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.Data.Migrations
{
    /// <inheritdoc />
    public partial class TestingChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Genres_Games_GameEntityGameId1",
                table: "Genres");

            migrationBuilder.DropIndex(
                name: "IX_Genres_GameEntityGameId1",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "GameEntityGameId1",
                table: "Genres");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GameEntityGameId1",
                table: "Genres",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Genres_GameEntityGameId1",
                table: "Genres",
                column: "GameEntityGameId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Genres_Games_GameEntityGameId1",
                table: "Genres",
                column: "GameEntityGameId1",
                principalTable: "Games",
                principalColumn: "GameId");
        }
    }
}
