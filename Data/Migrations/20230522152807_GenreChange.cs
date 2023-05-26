using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.Data.Migrations
{
    /// <inheritdoc />
    public partial class GenreChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Genres_Games_GameEntityGameId",
                table: "Genres");

            migrationBuilder.DropIndex(
                name: "IX_Genres_GameEntityGameId",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "GameEntityGameId",
                table: "Genres");

            migrationBuilder.AddColumn<int>(
                name: "GenreId",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Games_GenreId",
                table: "Games",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Genres_GenreId",
                table: "Games",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "GenreId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Genres_GenreId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_GenreId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "Games");

            migrationBuilder.AddColumn<int>(
                name: "GameEntityGameId",
                table: "Genres",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Genres_GameEntityGameId",
                table: "Genres",
                column: "GameEntityGameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Genres_Games_GameEntityGameId",
                table: "Genres",
                column: "GameEntityGameId",
                principalTable: "Games",
                principalColumn: "GameId");
        }
    }
}
