using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using tareaBase.Data;
using tareaBase.Modelo;

namespace tareaBase.Pages.Zoologicos
{
    public class IndexModel : PageModel
    {
        private readonly tareaBase.Data.tareaBaseContext _context;

        public IndexModel(tareaBase.Data.tareaBaseContext context)
        {
            _context = context;
        }

        public IList<Zoologico> Zoologico { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Zoologico != null)
            {
                Zoologico = await _context.Zoologico.ToListAsync();
            }
        }
    }
}
