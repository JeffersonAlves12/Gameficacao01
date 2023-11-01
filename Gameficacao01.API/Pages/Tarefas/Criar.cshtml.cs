using Gameficacao01.API.Data;
using Gameficacao01.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gameficacao01.API.Pages.Tarefas
{
    public class Criar : PageModel
    {
        private readonly AppDbContext _context;

        // Adicionando uma lista de sprints e projetos para seleção.
        public List<SprintModel> Sprints { get; set; }
        public List<ProjetoModel> Projetos { get; set; }

        public Criar(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TarefaModel Tarefa { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            // Obtendo os sprints e projetos disponíveis
            Sprints = await _context.Sprints.ToListAsync();
            Projetos = await _context.Projetos.ToListAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Tarefas.Add(Tarefa);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Tarefas/Index");
        }
    }
}
