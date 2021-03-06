using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Player.Models;

namespace FinalProject.Pages.Items
{
    public class DetailsModel : PageModel
    {
        private readonly Player.Models.CharacterDbContext _context;

        public DetailsModel(Player.Models.CharacterDbContext context)
        {
            _context = context;
        }

        public Item Item { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Item = await _context.Items.FirstOrDefaultAsync(m => m.ItemID == id);

            if (Item == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
