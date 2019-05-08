using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Player.Models
{
    public class Item
    {
        public int ItemID {get; set;}

        public string ItemName {get; set;} // item name
        public string ItemFlvrTxt {get; set;} //item descritpion
        public string ItemAbil {get; set;} //item effects and abilities

        public List<Char2Item> Characters { get; set; }

    }
}