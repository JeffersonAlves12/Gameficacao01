using System;
using System.Threading.Tasks;
using Gameficacao01.API.Data;
using Gameficacao01.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Gameficacao01.API.Pages.Projetos
{
    public class Deletar : PageModel
    {
        private readonly AppDbContext _context;
        [BindProperty]
        public ProjetoModel ProjetoModel { get; set; }
        public String ErrorMessage { get; set; }

        public Deletar(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
        {
            if (id == null || _context.Projetos == null)
            {
                return NotFound();
            }

            var projeto = await _context.Projetos.FirstOrDefaultAsync(p => p.Id == id);

            if (projeto == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = String.Format("A exclusão do projeto com ID {0} falhou. Tente novamente", id);
            }

            ProjetoModel = projeto;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var projetoToRemove = await _context.Projetos.FindAsync(id);

            if (projetoToRemove == null)
            {
                return NotFound();
            }

            try
            {
                _context.Projetos.Remove(projetoToRemove);
                await _context.SaveChangesAsync();
                return RedirectToPage("/Projetos/Index");
            }
            catch (DbUpdateException)
            {
                return RedirectToAction("./Deletar", new { id, saveChangesError = true });
            }
        }
    }
}
