using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gameficacao01.API.Data;
using Gameficacao01.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Gameficacao01.API.Pages.Tarefas
{
    public class Index : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string FiltroNome { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Ordenacao { get; set; }

        private readonly AppDbContext _context;
        public List<TarefaModel> TarefaList { get; set; } = new();

        public Index(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var query = _context.Tarefas.AsQueryable();

            if (!string.IsNullOrEmpty(FiltroNome))
            {
                query = query.Where(t => t.Nome.Contains(FiltroNome));
            }

            switch (Ordenacao)
            {
                case "NomeAsc":
                    query = query.OrderBy(t => t.Nome);
                    break;
                case "DataVencimentoDesc":
                    query = query.OrderByDescending(t => t.DataVencimento);
                    break;
                default:
                    query = query.OrderBy(t => t.Nome);
                    break;
            }

            TarefaList = await query.ToListAsync();

            return Page();
        }
    }
}
