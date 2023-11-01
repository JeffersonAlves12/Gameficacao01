using System;
using System.Threading.Tasks;
using Gameficacao01.API.Data;
using Gameficacao01.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Gameficacao01.API.Pages.Clientes
{
    public class Deletar : PageModel
    {
        private readonly AppDbContext _context;
        [BindProperty]
        public ClienteModel ClienteModel { get; set; }
        public String ErrorMessage { get; set; }

        public Deletar(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
        {
            if (id == null || _context.Clientes == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Id == id);

            if (cliente == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = String.Format("A exclusão do cliente com ID {0} falhou. Tente novamente", id);
            }

            ClienteModel = cliente;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var clienteToRemove = await _context.Clientes.FindAsync(id);

            if (clienteToRemove == null)
            {
                return NotFound();
            }

            try
            {
                _context.Clientes.Remove(clienteToRemove);
                await _context.SaveChangesAsync();
                return RedirectToPage("/Clientes/Index");
            }
            catch (DbUpdateException)
            {
                return RedirectToAction("./Deletar", new { id, saveChangesError = true });
            }
        }
    }
}
