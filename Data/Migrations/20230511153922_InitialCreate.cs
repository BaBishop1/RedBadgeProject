using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Creators",
                columns: table => new
                {
                    CreatorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Creators", x => x.CreatorId);
                });

            migrationBuilder.CreateTable(
                name: "Logins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoginType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PLayerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PLayerId);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    GameTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GameDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateUploaded = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    PlayerEntityPLayerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameId);
                    table.ForeignKey(
                        name: "FK_Games_Creators_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Creators",
                        principalColumn: "CreatorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Games_Players_PlayerEntityPLayerId",
                        column: x => x.PlayerEntityPLayerId,
                        principalTable: "Players",
                        principalColumn: "PLayerId");
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenreName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GenreDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GameEntityGameId = table.Column<int>(type: "int", nullable: true),
                    GameEntityGameId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreId);
                    table.ForeignKey(
                        name: "FK_Genres_Games_GameEntityGameId",
                        column: x => x.GameEntityGameId,
                        principalTable: "Games",
                        principalColumn: "GameId");
                    table.ForeignKey(
                        name: "FK_Genres_Games_GameEntityGameId1",
                        column: x => x.GameEntityGameId1,
                        principalTable: "Games",
                        principalColumn: "GameId");
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    ReviewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    GameScore = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_Ratings_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_CreatorId",
                table: "Games",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_PlayerEntityPLayerId",
                table: "Games",
                column: "PlayerEntityPLayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_GameEntityGameId",
                table: "Genres",
                column: "GameEntityGameId");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_GameEntityGameId1",
                table: "Genres",
                column: "GameEntityGameId1");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_GameId",
                table: "Ratings",
                column: "GameId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Logins");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Creators");

            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
