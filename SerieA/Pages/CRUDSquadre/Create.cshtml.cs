using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SerieA.Data;
using SerieA.Models;

namespace SerieA.Pages.CRUDSquadre
{
    public class CreateModel : PageModel
    {
        private readonly SerieA.Data.SerieAContext _context;

        public CreateModel(SerieA.Data.SerieAContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Squadra Squadra { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Squadra.Add(Squadra);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
