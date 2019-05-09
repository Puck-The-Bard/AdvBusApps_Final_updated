using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Player.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CharacterDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<CharacterDbContext>>()))
            {
                // Look for any characters.
                if (context.Characters.Any())
                {
                    return;   // DB has been seeded
                }

                context.Characters.AddRange(
                    new Character
                    {
                        CharacterName = "Kevin",
                        FlavorText = "A wizard that isn't as powerful as he thinks he is",
                        Health = 1,
                        Level = 1,
                        Strength = 1,
                        Dexterity = 1,
                        Constitution = 1,
                        Intelligence = 1,
                        Wisdom = 1,
                        Charasma = 1,
                    },
                    new Character
                    {
                        CharacterName = "Mark",
                        FlavorText = "A middle aged man that is trying to start a swimming pool business in the middle ages",
                        Health = 2,
                        Level = 2,
                        Strength = 3,
                        Dexterity = 2,
                        Constitution = 2,
                        Intelligence = 2,
                        Wisdom = 2,
                        Charasma = 2,
                    },
                    new Character
                    {
                        CharacterName = "Joe",
                        FlavorText = "Thinks Mark is an idiot, no other real character traits",
                        Health = 68,
                        Level = 3,
                        Strength = 5,
                        Dexterity = 5,
                        Constitution = 6,
                        Intelligence = 6,
                        Wisdom = 7,
                        Charasma = 8,
                    },
                    new Character
                    {
                        CharacterName = "Smo",
                        FlavorText = "Gentle Giant of a man that really loves cupcakes.  Bouncer at the inn",
                        Health = 15,
                        Level = 4,
                        Strength = 1,
                        Dexterity = 2,
                        Constitution = 3,
                        Intelligence = 4,
                        Wisdom = 5,
                        Charasma = 6,
                    },
                    new Character
                    {
                        CharacterName = "Dilibard the Dispoiler",
                        FlavorText = "Puts salt in peoples milk",
                        Health = 23,
                        Level = 22,
                        Strength = 10,
                        Dexterity = 2,
                        Constitution = 12,
                        Intelligence = 5,
                        Wisdom = 1,
                        Charasma = 0,
                    },
                    new Character
                    {
                        CharacterName = "Zero",
                        FlavorText = "nothing and everything, he is all",
                        Health = 0,
                        Level = 0,
                        Strength = 0,
                        Dexterity = 0,
                        Constitution = 0,
                        Intelligence = 0,
                        Wisdom = 0,
                        Charasma = 0,
                    },
                    new Character
                    {
                        CharacterName = "Puck The Bard",
                        FlavorText = "Likes to yell at strangers when drunk.  Moderately good at playing the Tin Whistle.",
                        Health = 15,
                        Level = 3,
                        Strength = 5,
                        Dexterity = 2,
                        Constitution = 2,
                        Intelligence = 3,
                        Wisdom = 2,
                        Charasma = 10,
                    },
                    new Character
                    {
                        CharacterName = "Nala",
                        FlavorText = "Lizard girl with a big sword.  Also a shapeshifter sometimes",
                        Health = 15,
                        Level = 3,
                        Strength = 5,
                        Dexterity = 5,
                        Constitution = 2,
                        Intelligence = 4,
                        Wisdom = 4,
                        Charasma = 5,
                    },
                    new Character
                    {
                        CharacterName = "Varis",
                        FlavorText = "An angry drunken murder hobo",
                        Health = 15,
                        Level = 4,
                        Strength = 10,
                        Dexterity = 10,
                        Constitution = 5,
                        Intelligence = 4,
                        Wisdom = 5,
                        Charasma = 1,
                    },
                    new Character
                    {
                        CharacterName = "Hoenheim",
                        FlavorText = "A wizard that is killed very easily",
                        Health = 1,
                        Level = 1,
                        Strength = 1,
                        Dexterity = 1,
                        Constitution = 1,
                        Intelligence = 1,
                        Wisdom = 1,
                        Charasma = 1,
                    },
                    new Character
                    {
                        CharacterName = "Arbosa",
                        FlavorText = "A pirate captin that trades in many goods legal and illegal.",
                        Health = 15,
                        Level = 3,
                        Strength = 5,
                        Dexterity = 3,
                        Constitution = 20,
                        Intelligence = 5,
                        Wisdom = 8,
                        Charasma = 3,
                    },
                    new Character
                    {
                        CharacterName = "Jimmy two shanks",
                        FlavorText = "He's got two shanks",
                        Health = 5,
                        Level = 5,
                        Strength = 10,
                        Dexterity = 10,
                        Constitution = 2,
                        Intelligence = 2,
                        Wisdom = 1,
                        Charasma = 1,
                    },
                    new Character
                    {
                        CharacterName = "One Tooth Tom",
                        FlavorText = "backwater hobo that plays the banjo, picking it with a tooth he lost in a bar fight",
                        Health = 5,
                        Level = 2,
                        Strength = 5,
                        Dexterity = 6,
                        Constitution = 2,
                        Intelligence = 5,
                        Wisdom = 2,
                        Charasma = 2,
                    },
                    new Character
                    {
                        CharacterName = "Jobo",
                        FlavorText = "Spy for secret organiztion",
                        Health = 3,
                        Level = 4,
                        Strength = 5,
                        Dexterity = 5,
                        Constitution = 6,
                        Intelligence = 9,
                        Wisdom = 9,
                        Charasma = 10,
                    },
                    new Character
                    {
                        CharacterName = "Aragorn",
                        FlavorText = "Aragorn son of Arathorn, the nine and thirtieth heir in the right line from Isildur, and yet more like Elendil than any before him.",
                        Health = 10,
                        Level = 10,
                        Strength = 10,
                        Dexterity = 20,
                        Constitution = 8,
                        Intelligence = 10,
                        Wisdom = 10,
                        Charasma = 10,
                    }
                    
                );
                context.Items.AddRange(
                    new Item
                    {
                       ItemName = "Sword of Sharpness",
                       ItemFlvrTxt = "A relatively sharp sword",
                       ItemAbil = "it cuts things" 
                    },
                    new Item
                    {
                       ItemName = "Piercing Whistle",
                       ItemFlvrTxt = "Casts Shatter once and then is destroyed",
                       ItemAbil = "1d6 Damage" 
                    },
                    new Item
                    {
                       ItemName = "Cloak of invisibility",
                       ItemFlvrTxt = "Made by a prankster wizard when asked by a king to make a cloak of invisibility, he was executed",
                       ItemAbil = "Makes user invisible but not the cloak itself which is a very lurid green" 
                    },
                    new Item
                    {
                       ItemName = "Jar of Bees",
                       ItemFlvrTxt = "It's a jar of ants, the label on the jar is misleading",
                       ItemAbil = "Can be thrown at enemies to stun them: 1d6 damage" 
                    },
                    new Item
                    {
                       ItemName = "A Fully Functional Program",
                       ItemFlvrTxt = "this one is only heard about in legend",
                       ItemAbil = "grarnts infinate power to the user" 
                    }
                );
                context.Spells.AddRange(
                    new Spell
                    {
                       SpellName = "Presdigitation",
                       SpellInstructions = "can make small sparks and illusion in the hand",
                       DamageRoll = "NA"
                    },
                    new Spell
                    {
                       SpellName = "Shatter",
                       SpellInstructions = "Piersing sound damages a target",
                       DamageRoll = "1d6"
                    },
                    new Spell
                    {
                       SpellName = "Debug",
                       SpellInstructions = "Illusiary magic, people get lost for eternity decifering the mystic texts it generates if they fail a wisdom save dc6",
                       DamageRoll = "1d20"
                    },
                    new Spell
                    {
                       SpellName = "Pocket Spa",
                       SpellInstructions = "Creates a Small 10x10 tent with spa attendants to cater to the caster.  Halves rest tmie",
                       DamageRoll = "NA"
                    },
                    new Spell
                    {
                       SpellName = "Create Food",
                       SpellInstructions = "Creates a jar of bees with an accurate label, careful don't mix up the jars",
                       DamageRoll = "1d10 and the area fills with bees"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}