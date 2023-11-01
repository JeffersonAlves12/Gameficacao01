using Gameficacao01.API.Data;
using Gameficacao01.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gameficacao01.API.Pages.Clientes
{
    public class Criar : PageModel
    {
        private readonly AppDbContext _context;

        // Adicionando uma lista de projetos para seleção.
        public List<ProjetoModel> Projetos { get; set; }

        public Criar(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ClienteModel Cliente { get; set; }

        [BindProperty]
        public int? SelectedProjetoId { get; set; } // para vincular ao projeto selecionado

        public async Task<IActionResult> OnGetAsync()
        {
            // Obtendo os projetos disponíveis
            Projetos = await _context.Projetos.ToListAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Se um projeto foi selecionado, adicione o relacionamento
            if (SelectedProjetoId.HasValue)
            {
                var projeto = await _context.Projetos.FindAsync(SelectedProjetoId.Value);
                if (projeto != null)
                {
                    Cliente.Projetos.Add(projeto);
                }
            }

            _context.Clientes.Add(Cliente);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Clientes/Index");
        }
    }
}
