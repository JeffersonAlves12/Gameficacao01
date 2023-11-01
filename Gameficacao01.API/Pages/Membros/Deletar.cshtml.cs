using System;
using System.Threading.Tasks;
using Gameficacao01.API.Data;
using Gameficacao01.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Gameficacao01.API.Pages.Membros
{
    public class Deletar : PageModel
    {
        private readonly AppDbContext _context;
        [BindProperty]
        public MembroModel MembroModel { get; set; }
        public String ErrorMessage { get; set; }

        public Deletar(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
        {
            if (id == null || _context.Membros == null)
            {
                return NotFound();
            }

            var membro = await _context.Membros.FirstOrDefaultAsync(m => m.Id == id);

            if (membro == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = String.Format("A exclusão do membro com ID {0} falhou. Tente novamente", id);
            }

            MembroModel = membro;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var membroToRemove = await _context.Membros.FindAsync(id);

            if (membroToRemove == null)
            {
                return NotFound();
            }

            try
            {
                _context.Membros.Remove(membroToRemove);
                await _context.SaveChangesAsync();
                return RedirectToPage("/Membros/Index");
            }
            catch (DbUpdateException)
            {
                return RedirectToAction("./Deletar", new { id, saveChangesError = true });
            }
        }
    }
}
