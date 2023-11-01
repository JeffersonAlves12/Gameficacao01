using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gameficacao01.API.Data;
using Gameficacao01.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Gameficacao01.API.Pages.Equipes
{
    public class Index : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string FiltroNome { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Ordenacao { get; set; }

        private readonly AppDbContext _context;
        public List<EquipeModel> EquipesList { get; set; } = new();

        public Index(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var query = _context.Equipes.Include(e => e.Projeto).AsQueryable();

            if (!string.IsNullOrEmpty(FiltroNome))
            {
                query = query.Where(e => e.Nome.Contains(FiltroNome));
            }

            switch (Ordenacao)
            {
                case "NomeAsc":
                    query = query.OrderBy(e => e.Nome);
                    break;
                default:
                    query = query.OrderBy(e => e.Nome);
                    break;
            }

            EquipesList = await query.ToListAsync();

            return Page();
        }
    }
}
