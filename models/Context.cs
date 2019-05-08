using System;
using Microsoft.EntityFrameworkCore;

namespace Player.Models
{
    public class CharacterDbContext : DbContext
    {
        public CharacterDbContext (DbContextOptions<CharacterDbContext> options) : base(options) { }

        public DbSet<Player.Models.Character> Characters { get; set; }
        public DbSet<Player.Models.Spell> Spells {get; set;}
        public DbSet<Player.Models.Item> Items {get; set;}


        //Bridge Table
        public DbSet<Player.Models.Char2Item> Char2Items {get; set;}

        public DbSet<Player.Models.Char2Spell> Char2Spell {get; set;}


         protected override void OnModelCreating(ModelBuilder modelBuilder) //creating bridge table composit keys
        {
        
            modelBuilder.Entity<Char2Item>()
            .HasKey(mc => new { mc.CharacterID, mc.ItemID });

            modelBuilder.Entity<Char2Spell>()
            .HasKey(sc => new { sc.CharacterID, sc.SpellID });


        } 
    }
}