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

namespace SerieA.Pages.CRUDCalciatori
{
    public class EditModel : PageModel
    {
        private readonly SerieA.Data.SerieAContext _context;

        public EditModel(SerieA.Data.SerieAContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Calciatore Calciatore { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calciatore =  await _context.Calciatore.FirstOrDefaultAsync(m => m.ID == id);
            if (calciatore == null)
            {
                return NotFound();
            }
            Calciatore = calciatore;
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

            _context.Attach(Calciatore).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CalciatoreExists(Calciatore.ID))
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

        private bool CalciatoreExists(int id)
        {
            return _context.Calciatore.Any(e => e.ID == id);
        }
    }
}
