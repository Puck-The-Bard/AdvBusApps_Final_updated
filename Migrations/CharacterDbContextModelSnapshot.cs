﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Player.Models;

namespace FinalProject.Migrations
{
    [DbContext(typeof(CharacterDbContext))]
    partial class CharacterDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity("Player.Models.Char2Item", b =>
                {
                    b.Property<int>("CharacterID");

                    b.Property<int>("ItemID");

                    b.Property<int>("Char2ItemID");

                    b.HasKey("CharacterID", "ItemID");

                    b.HasIndex("ItemID");

                    b.ToTable("Char2Items");
                });

            modelBuilder.Entity("Player.Models.Char2Spell", b =>
                {
                    b.Property<int>("CharacterID");

                    b.Property<int>("SpellID");

                    b.Property<int>("Char2SpellID");

                    b.HasKey("CharacterID", "SpellID");

                    b.HasIndex("SpellID");

                    b.ToTable("Char2Spell");
                });

            modelBuilder.Entity("Player.Models.Character", b =>
                {
                    b.Property<int>("CharacterID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CharacterName");

                    b.Property<int>("Charasma");

                    b.Property<int>("Constitution");

                    b.Property<int>("Dexterity");

                    b.Property<string>("FlavorText");

                    b.Property<int>("Health");

                    b.Property<int>("Intelligence");

                    b.Property<int>("Level");

                    b.Property<int?>("SpellID");

                    b.Property<int>("Strength");

                    b.Property<int>("Wisdom");

                    b.HasKey("CharacterID");

                    b.HasIndex("SpellID");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("Player.Models.Item", b =>
                {
                    b.Property<int>("ItemID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ItemAbil");

                    b.Property<string>("ItemFlvrTxt");

                    b.Property<string>("ItemName");

                    b.HasKey("ItemID");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Player.Models.Spell", b =>
                {
                    b.Property<int>("SpellID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DamageRoll");

                    b.Property<string>("SpellInstructions");

                    b.Property<string>("SpellName");

                    b.HasKey("SpellID");

                    b.ToTable("Spells");
                });

            modelBuilder.Entity("Player.Models.Char2Item", b =>
                {
                    b.HasOne("Player.Models.Character", "Character")
                        .WithMany("Items")
                        .HasForeignKey("CharacterID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Player.Models.Item", "Item")
                        .WithMany("Characters")
                        .HasForeignKey("ItemID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Player.Models.Char2Spell", b =>
                {
                    b.HasOne("Player.Models.Character", "Character")
                        .WithMany("Spells")
                        .HasForeignKey("CharacterID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Player.Models.Spell", "Spell")
                        .WithMany()
                        .HasForeignKey("SpellID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Player.Models.Character", b =>
                {
                    b.HasOne("Player.Models.Spell")
                        .WithMany("Characters")
                        .HasForeignKey("SpellID");
                });
#pragma warning restore 612, 618
        }
    }
}
