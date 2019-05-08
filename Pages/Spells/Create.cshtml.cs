using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Player.Models;

namespace FinalProject.Pages.Spells
{
    public class CreateModel : PageModel
    {
        private readonly Context _context;

        public CreateModel(Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Spell Spell { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Spell.Add(Spell);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}