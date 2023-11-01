using System;
using System.Linq;
using System.Threading.Tasks;
using Gameficacao01.API.Data;
using Gameficacao01.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Gameficacao01.API.Pages.Sprints
{
    public class Atualizar : PageModel
    {
        private readonly AppDbContext _context;
        [BindProperty]
        public SprintModel SprintModel { get; set; } = new();

        public Atualizar(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sprintModel = await _context.Sprints.Include(s => s.Tarefas).FirstOrDefaultAsync(s => s.Id == id);

            if (sprintModel == null)
            {
                return NotFound();
            }

            SprintModel = sprintModel;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var sprintToUpdate = await _context.Sprints.Include(s => s.Tarefas).FirstOrDefaultAsync(s => s.Id == id);

            if (sprintToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<SprintModel>(
                sprintToUpdate,
                "SprintModel",
                s => s.Nome, s => s.DataInicio, s => s.DataTermino))
            {
                // Aqui você pode lidar com outras atualizações, como atualizar tarefas associadas, se necessário
                await _context.SaveChangesAsync();
                return RedirectToPage("/Sprints/Index");
            }

            return Page();
        }
    }
}
