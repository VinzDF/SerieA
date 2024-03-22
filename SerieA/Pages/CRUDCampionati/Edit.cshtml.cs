using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SerieA.Data;
using SerieA.Models;

namespace SerieA.Pages.CRUDCampionati
{
    public class EditModel : PageModel
    {
        private readonly SerieA.Data.SerieAContext _context;

        public EditModel(SerieA.Data.SerieAContext context)
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

            var campionato =  await _context.Campionato.FirstOrDefaultAsync(m => m.Id == id);
            if (campionato == null)
            {
                return NotFound();
            }
            Campionato = campionato;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Campionato).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CampionatoExists(Campionato.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CampionatoExists(int id)
        {
            return _context.Campionato.Any(e => e.Id == id);
        }
    }
}
