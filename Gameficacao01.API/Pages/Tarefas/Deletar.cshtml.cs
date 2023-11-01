using System;
using System.Threading.Tasks;
using Gameficacao01.API.Data;
using Gameficacao01.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Gameficacao01.API.Pages.Tarefas
{
    public class Deletar : PageModel
    {
        private readonly AppDbContext _context;
        [BindProperty]
        public TarefaModel TarefaModel { get; set; }
        public String ErrorMessage { get; set; }

        public Deletar(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
        {
            if (id == null || _context.Tarefas == null)
            {
                return NotFound();
            }

            var tarefa = await _context.Tarefas.FirstOrDefaultAsync(p => p.Id == id);

            if (tarefa == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = String.Format("A exclusão da tarefa com ID {0} falhou. Tente novamente", id);
            }

            TarefaModel = tarefa;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var tarefaToRemove = await _context.Tarefas.FindAsync(id);

            if (tarefaToRemove == null)
            {
                return NotFound();
            }

            try
            {
                _context.Tarefas.Remove(tarefaToRemove);
                await _context.SaveChangesAsync();
                return RedirectToPage("/Tarefas/Index");
            }
            catch (DbUpdateException)
            {
                return RedirectToAction("./Deletar", new { id, saveChangesError = true });
            }
        }
    }
}
