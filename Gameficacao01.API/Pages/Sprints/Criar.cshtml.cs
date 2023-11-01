using Gameficacao01.API.Data;
using Gameficacao01.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gameficacao01.API.Pages.Sprints
{
    public class Criar : PageModel
    {
        private readonly AppDbContext _context;

        // Adicionando uma lista de tarefas para seleção.
        public List<TarefaModel> Tarefas { get; set; }

        public Criar(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SprintModel Sprint { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            // Obtendo as tarefas disponíveis
            Tarefas = await _context.Tarefas.ToListAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Sprints.Add(Sprint);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Sprints/Index");
        }
    }
}
