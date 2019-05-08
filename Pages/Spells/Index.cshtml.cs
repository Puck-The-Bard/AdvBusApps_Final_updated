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
    public class IndexModel : PageModel
    {
        private readonly Player.Models.CharacterDbContext _context;

        public IndexModel(Player.Models.CharacterDbContext context)
        {
            _context = context;
        }

        public IList<Spell> Spell { get;set; }

        public async Task OnGetAsync()
        {
            Spell = await _context.Spells.ToListAsync();
        }
    }
}
