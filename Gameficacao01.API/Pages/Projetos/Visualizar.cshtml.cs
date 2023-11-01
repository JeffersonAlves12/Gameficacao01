using System.Threading.Tasks;
using Gameficacao01.API.Data;
using Gameficacao01.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Gameficacao01.API.Pages.Projetos
{
    public class Visualizar : PageModel
    {
        private readonly AppDbContext _context;

        public Visualizar(AppDbContext context)
        {
            _context = context;
        }

        public ProjetoModel Projeto { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Projeto = await _context.Projetos
                .Include(p => p.Tarefas)
                .Include(p => p.Equipe)
                .Include(p => p.Clientes)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Projeto == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
