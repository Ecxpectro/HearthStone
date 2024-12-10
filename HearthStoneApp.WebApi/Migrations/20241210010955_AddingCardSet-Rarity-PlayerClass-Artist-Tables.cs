using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HearthStoneApp.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class AddingCardSetRarityPlayerClassArtistTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ArtistId",
                table: "Cards",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CardSetId",
                table: "Cards",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PlayerClassId",
                table: "Cards",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "RarityId",
                table: "Cards",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Artist",
                columns: table => new
                {
                    ArtistId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artist", x => x.ArtistId);
                });

            migrationBuilder.CreateTable(
                name: "CardSet",
                columns: table => new
                {
                    CardSetId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardSet", x => x.CardSetId);
                });

            migrationBuilder.CreateTable(
                name: "PlayerClass",
                columns: table => new
                {
                    PlayerClassId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerClass", x => x.PlayerClassId);
                });

            migrationBuilder.CreateTable(
                name: "Rarity",
                columns: table => new
                {
                    RarityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rarity", x => x.RarityId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cards_ArtistId",
                table: "Cards",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_CardSetId",
                table: "Cards",
                column: "CardSetId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_PlayerClassId",
                table: "Cards",
                column: "PlayerClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_RarityId",
                table: "Cards",
                column: "RarityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Artist_ArtistId",
                table: "Cards",
                column: "ArtistId",
                principalTable: "Artist",
                principalColumn: "ArtistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_CardSet_CardSetId",
                table: "Cards",
                column: "CardSetId",
                principalTable: "CardSet",
                principalColumn: "CardSetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_PlayerClass_PlayerClassId",
                table: "Cards",
                column: "PlayerClassId",
                principalTable: "PlayerClass",
                principalColumn: "PlayerClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Rarity_RarityId",
                table: "Cards",
                column: "RarityId",
                principalTable: "Rarity",
                principalColumn: "RarityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Artist_ArtistId",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Cards_CardSet_CardSetId",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Cards_PlayerClass_PlayerClassId",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Rarity_RarityId",
                table: "Cards");

            migrationBuilder.DropTable(
                name: "Artist");

            migrationBuilder.DropTable(
                name: "CardSet");

            migrationBuilder.DropTable(
                name: "PlayerClass");

            migrationBuilder.DropTable(
                name: "Rarity");

            migrationBuilder.DropIndex(
                name: "IX_Cards_ArtistId",
                table: "Cards");

            migrationBuilder.DropIndex(
                name: "IX_Cards_CardSetId",
                table: "Cards");

            migrationBuilder.DropIndex(
                name: "IX_Cards_PlayerClassId",
                table: "Cards");

            migrationBuilder.DropIndex(
                name: "IX_Cards_RarityId",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "ArtistId",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "CardSetId",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "PlayerClassId",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "RarityId",
                table: "Cards");
        }
    }
}
