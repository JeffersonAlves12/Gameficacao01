using Gameficacao01.API.Data;
using Gameficacao01.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;

namespace Gameficacao01.API.Pages.Membros
{
    public class Criar : PageModel
    {
        private readonly AppDbContext _context;

        public Criar(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MembroModel Membro { get; set; }

        // Para popular o dropdown de equipes
        public SelectList Equipes { get; set; }

        public void OnGet()
        {
            // Obtendo as equipes para a lista dropdown
            Equipes = new SelectList(_context.Equipes, "Id", "Nome");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Membros.Add(Membro);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Membros/Index");
        }
    }
}
