using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HearthStoneApp.Aplication.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRarityTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "Rarities");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                table: "Rarities",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
