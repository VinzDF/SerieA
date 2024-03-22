using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SerieA.Data;
using SerieA.Models;

namespace SerieA.Pages.CRUDSquadre
{
    public class DeleteModel : PageModel
    {
        private readonly SerieA.Data.SerieAContext _context;

        public DeleteModel(SerieA.Data.SerieAContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Squadra Squadra { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var squadra = await _context.Squadra.FirstOrDefaultAsync(m => m.Id == id);

            if (squadra == null)
            {
                return NotFound();
            }
            else
            {
                Squadra = squadra;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var squadra = await _context.Squadra.FindAsync(id);
            if (squadra != null)
            {
                Squadra = squadra;
                _context.Squadra.Remove(Squadra);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
