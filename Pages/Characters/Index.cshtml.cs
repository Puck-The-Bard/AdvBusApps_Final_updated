using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Player.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        [BindProperty(SupportsGet = true)]
        public string CurrentSort {get; set;}

        public SelectList SortList {get; set;}

         [BindProperty(SupportsGet = true)]
        public int PageNum { get; set;} = 1;
        public int PageSize {get; set;} = 5;

        [BindProperty(SupportsGet = true)]
        public int LastPage {get; set;}

        public async Task OnGetAsync()
        {
            var PageQuery = _context.Characters.Select(p => p).Count(); //getting total number of characters
            LastPage = (int)Math.Ceiling(Convert.ToDecimal(PageQuery)/5);

            Character = await _context.Characters.ToListAsync();

            var query = _context.Characters.Select(p => p);
            List<SelectListItem> sortItems = new List<SelectListItem> {
                new SelectListItem { Text = "FirstName Ascending", Value = "first_asc" },
                new SelectListItem { Text = "FirstName Descending", Value = "first_desc"}
            };
            SortList = new SelectList(sortItems, "Value", "Text", CurrentSort);

            switch (CurrentSort)
            {
                case "first_asc":
                    query = query.OrderBy(p => p.CharacterName);
                    break;
                case "first_desc":
                    query = query.OrderByDescending(p => p.Level);
                    break;
            }

            Character = await query.Skip((PageNum-1)*PageSize).Take(PageSize).ToListAsync();
        }
    }
}
