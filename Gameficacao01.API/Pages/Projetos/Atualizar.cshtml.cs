using System;
using System.Linq;
using System.Threading.Tasks;
using Gameficacao01.API.Data;
using Gameficacao01.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Gameficacao01.API.Pages.Projetos
{
    public class Atualizar : PageModel
    {
        private readonly AppDbContext _context;
        [BindProperty]
        public ProjetoModel ProjetoModel { get; set; } = new();

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

            var projetoModel = await _context.Projetos.Include(p => p.Tarefas).FirstOrDefaultAsync(p => p.Id == id);

            if (projetoModel == null)
            {
                return NotFound();
            }

            ProjetoModel = projetoModel;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var projetoToUpdate = await _context.Projetos.Include(p => p.Tarefas).FirstOrDefaultAsync(p => p.Id == id);

            if (projetoToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<ProjetoModel>(
                projetoToUpdate,
                "ProjetoModel",
                p => p.Nome, p => p.Descricao, p => p.DataInicio, p => p.DataConclusaoPrevista, p => p.Status))
            {
                // Aqui você pode lidar com outras atualizações, como atualizar tarefas associadas, se necessário
                await _context.SaveChangesAsync();
                return RedirectToPage("/Projetos/Index");
            }

            return Page();
        }
    }
}
