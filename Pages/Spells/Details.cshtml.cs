using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Player.Models;

namespace FinalProject.Pages.Spells
{
    public class DetailsModel : PageModel
    {
        private readonly Player.Models.CharacterDbContext _context;

        public DetailsModel(Player.Models.CharacterDbContext context)
        {
            _context = context;
        }

        public Spell Spell { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Spell = await _context.Spells.FirstOrDefaultAsync(m => m.SpellID == id);

            if (Spell == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
