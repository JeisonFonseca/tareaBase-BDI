using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using tareaBase.Data;
using tareaBase.Modelo;

namespace tareaBase.Pages.Zoologicos
{
    public class EditModel : PageModel
    {
        private readonly tareaBase.Data.tareaBaseContext _context;

        public EditModel(tareaBase.Data.tareaBaseContext context)
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

            var zoologico =  await _context.Zoologico.FirstOrDefaultAsync(m => m.id == id);
            if (zoologico == null)
            {
                return NotFound();
            }
            Zoologico = zoologico;
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

            _context.Attach(Zoologico).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZoologicoExists(Zoologico.id))
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

        private bool ZoologicoExists(int id)
        {
          return (_context.Zoologico?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
