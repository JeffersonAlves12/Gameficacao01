using System;
using System.Linq;
using System.Threading.Tasks;
using Gameficacao01.API.Data;
using Gameficacao01.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Gameficacao01.API.Pages.Tarefas
{
    public class Atualizar : PageModel
    {
        private readonly AppDbContext _context;
        [BindProperty]
        public TarefaModel TarefaModel { get; set; } = new();

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

            var tarefaModel = await _context.Tarefas.FirstOrDefaultAsync(t => t.Id == id);

            if (tarefaModel == null)
            {
                return NotFound();
            }

            TarefaModel = tarefaModel;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var tarefaToUpdate = await _context.Tarefas.FirstOrDefaultAsync(t => t.Id == id);

            if (tarefaToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<TarefaModel>(
                tarefaToUpdate,
                "TarefaModel",
                t => t.Nome, t => t.Descricao, t => t.Status, t => t.Responsavel, t => t.DataVencimento))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("/Tarefas/Index");
            }

            return Page();
        }
    }
}
