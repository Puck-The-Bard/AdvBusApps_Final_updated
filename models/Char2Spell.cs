using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Player.Models
{
    public class Char2Spell
    {
       // public int Char2SpellID {get; set;}

        public int CharacterID {get; set;} //pk
          public Character Character {get; set;} //nav property

        public int SpellID {get; set;} //pk
          public Spell Spell {get; set;} //nav property

    }
}