using System;
using System.Threading.Tasks;
using Gameficacao01.API.Data;
using Gameficacao01.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Gameficacao01.API.Pages.Equipes
{
    public class Deletar : PageModel
    {
        private readonly AppDbContext _context;
        [BindProperty]
        public EquipeModel EquipeModel { get; set; }
        public String ErrorMessage { get; set; }

        public Deletar(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
        {
            if (id == null || _context.Equipes == null)
            {
                return NotFound();
            }

            var equipe = await _context.Equipes.FirstOrDefaultAsync(e => e.Id == id);

            if (equipe == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = String.Format("A exclusão da equipe com ID {0} falhou. Tente novamente", id);
            }

            EquipeModel = equipe;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var equipeToRemove = await _context.Equipes.FindAsync(id);

            if (equipeToRemove == null)
            {
                return NotFound();
            }

            try
            {
                _context.Equipes.Remove(equipeToRemove);
                await _context.SaveChangesAsync();
                return RedirectToPage("/Equipes/Index");
            }
            catch (DbUpdateException)
            {
                return RedirectToAction("./Deletar", new { id, saveChangesError = true });
            }
        }
    }
}
