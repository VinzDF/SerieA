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
    public class IndexModel : PageModel
    {
        private readonly SerieA.Data.SerieAContext _context;

        public IndexModel(SerieA.Data.SerieAContext context)
        {
            _context = context;
        }

        public IList<Calciatore> Calciatore { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Calciatore = await _context.Calciatore.ToListAsync();
        }
    }
}
