using Gameficacao01.API.Data;
using Gameficacao01.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gameficacao01.API.Pages.Equipes
{
    public class Criar : PageModel
    {
        private readonly AppDbContext _context;

        // Adicionando uma lista de membros para seleção.
        public List<MembroModel> Membros { get; set; }

        [BindProperty]
        public EquipeModel Equipe { get; set; }

        [BindProperty]
        public int[] SelectedMembros { get; set; } // Para armazenar os membros selecionados

        public Criar(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            // Obtendo os membros disponíveis
            Membros = await _context.Membros.ToListAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var membrosSelecionados = _context.Membros.Where(m => SelectedMembros.Contains(m.Id)).ToList();
            foreach (var membro in membrosSelecionados)
            {
                Equipe.Membros.Add(membro);
            }

            _context.Equipes.Add(Equipe);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Equipes/Index");
        }
    }
}
