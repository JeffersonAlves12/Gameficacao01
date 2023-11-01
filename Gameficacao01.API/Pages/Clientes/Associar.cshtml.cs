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
    public class Associar : PageModel
    {
        private readonly AppDbContext _context;

        public Associar(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public int ClienteId { get; set; }
        
        [BindProperty]
        public int ProjetoId { get; set; }

        public List<ClienteModel> Clientes { get; set; }
        public List<ProjetoModel> Projetos { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Clientes = await _context.Clientes.ToListAsync();
            Projetos = await _context.Projetos.ToListAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var cliente = await _context.Clientes.Include(c => c.Projetos)
                                                 .FirstOrDefaultAsync(c => c.Id == ClienteId);
            var projeto = await _context.Projetos.FirstOrDefaultAsync(p => p.Id == ProjetoId);

            if (cliente == null || projeto == null)
            {
                return NotFound();
            }

            cliente.Projetos.Add(projeto);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
