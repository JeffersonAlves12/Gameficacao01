using System;
using System.Linq;
using System.Threading.Tasks;
using Gameficacao01.API.Data;
using Gameficacao01.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Gameficacao01.API.Pages.Membros
{
    public class Atualizar : PageModel
    {
        private readonly AppDbContext _context;
        [BindProperty]
        public MembroModel MembroModel { get; set; } = new();

        public Atualizar(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membroModel = await _context.Membros.FirstOrDefaultAsync(m => m.Id == id);

            if (membroModel == null)
            {
                return NotFound();
            }

            MembroModel = membroModel;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var membroToUpdate = await _context.Membros.FirstOrDefaultAsync(m => m.Id == id);

            if (membroToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<MembroModel>(
                membroToUpdate,
                "MembroModel",
                m => m.Nome ,
                m => m.Papel /*, adicione outros campos conforme necessário */))
                
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("/Membros/Index");
            }

            return Page();
        }
    }
}
