﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ItemName = table.Column<string>(nullable: true),
                    ItemFlvrTxt = table.Column<string>(nullable: true),
                    ItemAbil = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemID);
                });

            migrationBuilder.CreateTable(
                name: "Spells",
                columns: table => new
                {
                    SpellID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SpellName = table.Column<string>(nullable: true),
                    SpellInstructions = table.Column<string>(nullable: true),
                    DamageRoll = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spells", x => x.SpellID);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    CharacterID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CharacterName = table.Column<string>(nullable: true),
                    FlavorText = table.Column<string>(nullable: true),
                    Health = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    Strength = table.Column<int>(nullable: false),
                    Dexterity = table.Column<int>(nullable: false),
                    Constitution = table.Column<int>(nullable: false),
                    Intelligence = table.Column<int>(nullable: false),
                    Wisdom = table.Column<int>(nullable: false),
                    Charasma = table.Column<int>(nullable: false),
                    SpellID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.CharacterID);
                    table.ForeignKey(
                        name: "FK_Characters_Spells_SpellID",
                        column: x => x.SpellID,
                        principalTable: "Spells",
                        principalColumn: "SpellID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Char2Items",
                columns: table => new
                {
                    CharacterID = table.Column<int>(nullable: false),
                    ItemID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Char2Items", x => new { x.CharacterID, x.ItemID });
                    table.ForeignKey(
                        name: "FK_Char2Items_Characters_CharacterID",
                        column: x => x.CharacterID,
                        principalTable: "Characters",
                        principalColumn: "CharacterID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Char2Items_Items_ItemID",
                        column: x => x.ItemID,
                        principalTable: "Items",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Char2Spell",
                columns: table => new
                {
                    CharacterID = table.Column<int>(nullable: false),
                    SpellID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Char2Spell", x => new { x.CharacterID, x.SpellID });
                    table.ForeignKey(
                        name: "FK_Char2Spell_Characters_CharacterID",
                        column: x => x.CharacterID,
                        principalTable: "Characters",
                        principalColumn: "CharacterID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Char2Spell_Spells_SpellID",
                        column: x => x.SpellID,
                        principalTable: "Spells",
                        principalColumn: "SpellID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Char2Items_ItemID",
                table: "Char2Items",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_Char2Spell_SpellID",
                table: "Char2Spell",
                column: "SpellID");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_SpellID",
                table: "Characters",
                column: "SpellID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Char2Items");

            migrationBuilder.DropTable(
                name: "Char2Spell");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Spells");
        }
    }
}
