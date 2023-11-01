using System.Threading.Tasks;
using Gameficacao01.API.Data;
using Gameficacao01.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Gameficacao01.API.Pages.Tarefas
{
    public class Visualizar : PageModel
    {
        private readonly AppDbContext _context;

        public Visualizar(AppDbContext context)
        {
            _context = context;
        }

        public TarefaModel Tarefa { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Tarefa = await _context.Tarefas
                .Include(t => t.Sprints)
                .Include(t => t.Projetos)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Tarefa == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
