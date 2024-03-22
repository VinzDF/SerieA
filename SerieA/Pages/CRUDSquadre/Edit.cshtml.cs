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

namespace SerieA.Pages.CRUDSquadre
{
    public class EditModel : PageModel
    {
        private readonly SerieA.Data.SerieAContext _context;

        public EditModel(SerieA.Data.SerieAContext context)
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

            var squadra =  await _context.Squadra.FirstOrDefaultAsync(m => m.Id == id);
            if (squadra == null)
            {
                return NotFound();
            }
            Squadra = squadra;
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

            _context.Attach(Squadra).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SquadraExists(Squadra.Id))
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

        private bool SquadraExists(int id)
        {
            return _context.Squadra.Any(e => e.Id == id);
        }
    }
}
