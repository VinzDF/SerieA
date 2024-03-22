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
    public class IndexModel : PageModel
    {
        private readonly SerieA.Data.SerieAContext _context;

        public IndexModel(SerieA.Data.SerieAContext context)
        {
            _context = context;
        }

        public IList<Squadra> Squadra { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Squadra = await _context.Squadra.ToListAsync();
        }
    }
}
