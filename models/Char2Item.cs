using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Player.Models
{
    public class Char2Item
    {
        public int CharacterID {get; set;} //nav property
          public Character Character {get; set;} //pk

        public int ItemID {get; set;} //mav property
          public Item Item {get; set;} //pk

    }
}