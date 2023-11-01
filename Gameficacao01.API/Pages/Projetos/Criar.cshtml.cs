using Gameficacao01.API.Data;
using Gameficacao01.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Gameficacao01.API.Pages.Projetos
{
    public class Criar : PageModel
    {
        private readonly AppDbContext _context;

        public Criar(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ProjetoModel Projeto { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Projetos.Add(Projeto);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Projetos/Index");
        }
    }
}
