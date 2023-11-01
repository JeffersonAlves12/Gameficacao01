using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gameficacao01.API.Data;
using Gameficacao01.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Gameficacao01.API.Pages.Sprints
{
    public class Index : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string FiltroNome { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Ordenacao { get; set; }

        private readonly AppDbContext _context;
        public List<SprintModel> SprintList { get; set; } = new();

        public Index(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var query = _context.Sprints.AsQueryable();

            if (!string.IsNullOrEmpty(FiltroNome))
            {
                query = query.Where(s => s.Nome.Contains(FiltroNome));
            }

            switch (Ordenacao)
            {
                case "NomeAsc":
                    query = query.OrderBy(s => s.Nome);
                    break;
                case "DataInicioDesc":
                    query = query.OrderByDescending(s => s.DataInicio);
                    break;
                default:
                    query = query.OrderBy(s => s.Nome);
                    break;
            }

            SprintList = await query.ToListAsync();

            return Page();
        }
    }
}
