using System.Threading.Tasks;
using Gameficacao01.API.Data;
using Gameficacao01.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Gameficacao01.API.Pages.Sprints
{
    public class Visualizar : PageModel
    {
        private readonly AppDbContext _context;

        public Visualizar(AppDbContext context)
        {
            _context = context;
        }

        public SprintModel Sprint { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Sprint = await _context.Sprints
                .Include(s => s.Tarefas)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Sprint == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
