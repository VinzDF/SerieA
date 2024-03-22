using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SerieA.Data;
using SerieA.Models;

namespace SerieA.Pages.CRUDCampionati
{
    public class DeleteModel : PageModel
    {
        private readonly SerieA.Data.SerieAContext _context;

        public DeleteModel(SerieA.Data.SerieAContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Campionato Campionato { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var campionato = await _context.Campionato.FirstOrDefaultAsync(m => m.Id == id);

            if (campionato == null)
            {
                return NotFound();
            }
            else
            {
                Campionato = campionato;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var campionato = await _context.Campionato.FindAsync(id);
            if (campionato != null)
            {
                Campionato = campionato;
                _context.Campionato.Remove(Campionato);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
