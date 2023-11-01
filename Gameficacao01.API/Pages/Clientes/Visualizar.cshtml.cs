using System.Threading.Tasks;
using Gameficacao01.API.Data;
using Gameficacao01.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Gameficacao01.API.Pages.Clientes
{
    public class Visualizar : PageModel
    {
        private readonly AppDbContext _context;

        public Visualizar(AppDbContext context)
        {
            _context = context;
        }

        public ClienteModel Cliente { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cliente = await _context.Clientes
                .Include(c => c.Projetos)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Cliente == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
