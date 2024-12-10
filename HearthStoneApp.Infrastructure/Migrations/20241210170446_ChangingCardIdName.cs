using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HearthStoneApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangingCardIdName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CardId",
                table: "Cards",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Cards",
                newName: "CardId");
        }
    }
}
