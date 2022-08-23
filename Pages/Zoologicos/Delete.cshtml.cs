using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using tareaBase.Data;
using tareaBase.Modelo;


/**
 * Encargado de la logica de eliminar un nuevo zoologico 
*/
namespace tareaBase.Pages.Zoologicos
{
    public class DeleteModel : PageModel
    {
        private readonly tareaBase.Data.tareaBaseContext _context;

        public DeleteModel(tareaBase.Data.tareaBaseContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Zoologico Zoologico { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Zoologico == null)
            {
                return NotFound();
            }

            var zoologico = await _context.Zoologico.FirstOrDefaultAsync(m => m.id == id);

            if (zoologico == null)
            {
                return NotFound();
            }
            else 
            {
                Zoologico = zoologico;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Zoologico == null)
            {
                return NotFound();
            }
            var zoologico = await _context.Zoologico.FindAsync(id);

            if (zoologico != null)
            {
                Zoologico = zoologico;
                _context.Zoologico.Remove(Zoologico);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
