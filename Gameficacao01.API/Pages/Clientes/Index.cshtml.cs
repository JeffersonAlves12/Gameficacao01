using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gameficacao01.API.Data;
using Gameficacao01.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Gameficacao01.API.Pages.Clientes
{
    public class Index : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string FiltroNome { get; set; }

        private readonly AppDbContext _context;
        public List<ClienteModel> ClienteList { get; set; } = new();

        public Index(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var query = _context.Clientes.Include(c => c.Projetos).AsQueryable(); // Incluindo projetos no carregamento

            if (!string.IsNullOrEmpty(FiltroNome))
            {
                query = query.Where(c => c.Nome.Contains(FiltroNome));
            }

            ClienteList = await query.ToListAsync();

            return Page();
        }
    }
}
