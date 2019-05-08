using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject.Migrations
{
    public partial class ItemName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ItemName",
                table: "Items",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Char2SpellID",
                table: "Char2Spell",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Char2ItemID",
                table: "Char2Items",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemName",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Char2SpellID",
                table: "Char2Spell");

            migrationBuilder.DropColumn(
                name: "Char2ItemID",
                table: "Char2Items");
        }
    }
}
