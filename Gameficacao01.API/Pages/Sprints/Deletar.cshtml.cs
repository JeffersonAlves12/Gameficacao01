using System;
using System.Threading.Tasks;
using Gameficacao01.API.Data;
using Gameficacao01.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Gameficacao01.API.Pages.Sprints
{
    public class Deletar : PageModel
    {
        private readonly AppDbContext _context;
        [BindProperty]
        public SprintModel SprintModel { get; set; }
        public String ErrorMessage { get; set; }

        public Deletar(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
        {
            if (id == null || _context.Sprints == null)
            {
                return NotFound();
            }

            var sprint = await _context.Sprints.FirstOrDefaultAsync(s => s.Id == id);

            if (sprint == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = String.Format("A exclusão da sprint com ID {0} falhou. Tente novamente", id);
            }

            SprintModel = sprint;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var sprintToRemove = await _context.Sprints.FindAsync(id);

            if (sprintToRemove == null)
            {
                return NotFound();
            }

            try
            {
                _context.Sprints.Remove(sprintToRemove);
                await _context.SaveChangesAsync();
                return RedirectToPage("/Sprints/Index");
            }
            catch (DbUpdateException)
            {
                return RedirectToAction("./Deletar", new { id, saveChangesError = true });
            }
        }
    }
}
