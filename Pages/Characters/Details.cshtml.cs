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
using Microsoft.Extensions.Logging;

namespace FinalProject.Pages.Characters
{
    public class DetailsModel : PageModel
    {

        private readonly Player.Models.CharacterDbContext _context;
        private readonly ILogger _log;

        public DetailsModel(Player.Models.CharacterDbContext context, ILogger<DetailsModel> log)
        {
            _context = context;
            _log = log;
        }

        public Character Character { get; set; }
        public Char2Item Char2Item {get; set;}
        public List<Item> AllItems {get; set;}
        public SelectList ItemDropDown {get; set;}

        [BindProperty]
        [Display(Name = "Item")]
        public int ItemIdToAdd {get; set;}
        [BindProperty]
        public int ItemIdToDelete {get; set;}

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Bring in related data with .Include and .ThenInclude
            Character = await _context.Characters.Include(s => s.Items).ThenInclude(sc => sc.Item).FirstOrDefaultAsync(m => m.CharacterID == id);
            AllItems = await _context.Items.ToListAsync();
            ItemDropDown = new SelectList(AllItems, "ItemID", "ItemName");

            if (Character == null)
            {
                return NotFound();
            }
            return Page();
        }
        public async Task<IActionResult> OnPostDeleteCourseAsync(int? id)
        {
            _log.LogWarning($"OnPost: Character Id {id}, DROP course {ItemIdToDelete}");
            if (id == null)
            {
                return NotFound();
            }

            Character = await _context.Characters.Include(s => s.Items).ThenInclude(sc => sc.Item).FirstOrDefaultAsync(m => m.CharacterID == id);
            AllItems = await _context.Items.ToListAsync();
            ItemDropDown = new SelectList(AllItems, "CourseID", "Description");
            
            if (Character == null)
            {
                return NotFound();
            }

            Char2Item ItemToDrop = _context.Char2Items.Find(ItemIdToDelete, id.Value);

            if (ItemToDrop != null)
            {
                _context.Remove(ItemToDrop);
                _context.SaveChanges();
            }
            else
            {
                _log.LogWarning("No items");
            }

            return RedirectToPage(new {id = id});
        }


        public async Task<IActionResult> OnPostAsync(int? id)
        {
            _log.LogWarning($"OnPost: Character Id {id}, ADD course {ItemIdToAdd}");
            if (ItemIdToAdd == 0)
            {
                ModelState.AddModelError("CourseIdToAdd", "This field is a required field.");
                return Page();
            }
            if (id == null)
            {
                return NotFound();
            }

            Character = await _context.Characters.Include(s => s.Items).ThenInclude(sc => sc.Item).FirstOrDefaultAsync(m => m.CharacterID == id);            
            AllItems = await _context.Items.ToListAsync();
            ItemDropDown = new SelectList(AllItems, "ItemID", "ItemName");

            if (Character == null)
            {
                return NotFound();
            }

            if (!_context.Char2Items.Any(sc => sc.ItemID == ItemIdToAdd && sc.CharacterID == id.Value))
            {
                Char2Item ItemToAdd = new Char2Item { CharacterID = id.Value, ItemID = ItemIdToAdd};
                _context.Add(ItemToAdd);
                _context.SaveChanges();
            }
            else
            {
                _log.LogWarning("");
            }

            // Best practice is that OnPost should redirect. This clears the form data.
            // FIXME: Can we just populate the routeValues from what is already there?
            return RedirectToPage(new {id = id});
        }
    }
}
