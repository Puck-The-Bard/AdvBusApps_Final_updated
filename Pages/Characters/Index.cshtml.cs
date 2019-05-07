using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Player.Models;

namespace FinalProject.Pages.Characters
{
    public class IndexModel : PageModel
    {
        private readonly Player.Models.CharacterDbContext _context;

        public IndexModel(Player.Models.CharacterDbContext context)
        {
            _context = context;
        }

        public IList<Character> Character { get;set; }

        public async Task OnGetAsync()
        {
            Character = await _context.Characters.ToListAsync();
        }
    }
}
