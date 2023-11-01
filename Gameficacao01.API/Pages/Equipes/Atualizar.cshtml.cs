using System;
using System.Linq;
using System.Threading.Tasks;
using Gameficacao01.API.Data;
using Gameficacao01.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Gameficacao01.API.Pages.Equipes
{
    public class Atualizar : PageModel
    {
        private readonly AppDbContext _context;
        [BindProperty]
        public EquipeModel EquipeModel { get; set; } = new();

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

            var equipeModel = await _context.Equipes.FirstOrDefaultAsync(e => e.Id == id);

            if (equipeModel == null)
            {
                return NotFound();
            }

            EquipeModel = equipeModel;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var equipeToUpdate = await _context.Equipes.FirstOrDefaultAsync(e => e.Id == id);

            if (equipeToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<EquipeModel>(
                equipeToUpdate,
                "EquipeModel",
                e => e.Nome,
                e => e.Descricao /*, adicione outros campos conforme necessário */))
                
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("/Equipes/Index");
            }

            return Page();
        }
    }
}
