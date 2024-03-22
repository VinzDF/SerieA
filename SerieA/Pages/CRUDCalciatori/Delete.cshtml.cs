using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SerieA.Data;
using SerieA.Models;

namespace SerieA.Pages.CRUDCalciatori
{
    public class DeleteModel : PageModel
    {
        private readonly SerieA.Data.SerieAContext _context;

        public DeleteModel(SerieA.Data.SerieAContext context)
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

            var calciatore = await _context.Calciatore.FirstOrDefaultAsync(m => m.ID == id);

            if (calciatore == null)
            {
                return NotFound();
            }
            else
            {
                Calciatore = calciatore;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calciatore = await _context.Calciatore.FindAsync(id);
            if (calciatore != null)
            {
                Calciatore = calciatore;
                _context.Calciatore.Remove(Calciatore);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
