using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Player.Models
{
    public class Spell
    {
        public int SpellID {get; set;}
        public string SpellName {get; set;}
        public string SpellInstructions {get; set;}
        public string DamageRoll {get; set;}

        public List<Character> Characters {get; set;}
    }
}