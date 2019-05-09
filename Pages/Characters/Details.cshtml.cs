using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Player.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Pages.Characters
{
    public class DetailsModel : PageModel
    {
        private readonly Player.Models.CharacterDbContext _context;

        public DetailsModel(Player.Models.CharacterDbContext context)
        {
            _context = context;
        }

        public Character Character { get; set; }

        public Item Item {get; set;}

        public Spell Spell {get; set;}
        
        public string Name {get; set;}

        [BindProperty(SupportsGet = true)]
        public int GetItemID{get; set;}

        public string SeachString {get; set;}

        public SelectList SelectItems{get; set;}


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var FindItem = _context.Char2Items.Where(it => it.ItemID == GetItemID).FirstOrDefault();


            new Char2Item
            {
                CharacterID = Character.CharacterID,
                ItemID = FindItem.ItemID
            };
            
             //get a list of all items
            SelectItems = new SelectList(_context.Items.OrderBy(c => c.ItemName).ToList(), "ItemID", "ItemName", id);

            if (id == null)
            {
                return NotFound();
            }

            Character = await _context.Characters.FirstOrDefaultAsync(m => m.CharacterID == id);

            if (Character == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
