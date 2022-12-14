using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using tareaBase.Data;
using tareaBase.Modelo;

/**
 * Encargado de la logica de crear un nuevo zoologico 
*/
namespace tareaBase.Pages.Zoologicos
{
    public class CreateModel : PageModel
    {
        private readonly tareaBase.Data.tareaBaseContext _context;

        public CreateModel(tareaBase.Data.tareaBaseContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Zoologico Zoologico { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Zoologico == null || Zoologico == null)
            {
                return Page();
            }

            _context.Zoologico.Add(Zoologico);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
