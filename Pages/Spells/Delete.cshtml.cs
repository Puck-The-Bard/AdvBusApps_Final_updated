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
    public class DeleteModel : PageModel
    {
        private readonly Context _context;

        public DeleteModel(Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Spell Spell { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Spell = await _context.Spell.FirstOrDefaultAsync(m => m.SpellID == id);

            if (Spell == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Spell = await _context.Spell.FindAsync(id);

            if (Spell != null)
            {
                _context.Spell.Remove(Spell);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
