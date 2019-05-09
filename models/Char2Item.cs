using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Player.Models
{
    public class Char2Item
    {
       // public int Char2ItemID {get; set;}

        public int CharacterID {get; set;} //pk
          public Character Character {get; set;} //nav property

        public int ItemID {get; set;} //pk
          public Item Item {get; set;} //nav property

    }
}