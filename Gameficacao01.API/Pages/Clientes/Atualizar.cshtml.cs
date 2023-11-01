using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gameficacao01.API.Data;
using Gameficacao01.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Gameficacao01.API.Pages.Clientes
{
    public class Atualizar : PageModel
    {
        private readonly AppDbContext _context;
        [BindProperty]
        public ClienteModel ClienteModel { get; set; } = new();

        [BindProperty]
        public int[] SelectedProjects { get; set; }

        public Atualizar(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Clientes == null)
            {
                return NotFound();
            }

            var clienteModel = await _context.Clientes.Include(c => c.Projetos).FirstOrDefaultAsync(c => c.Id == id);

            if (clienteModel == null)
            {
                return NotFound();
            }

            ClienteModel = clienteModel;
            SelectedProjects = ClienteModel.Projetos.Select(p => p.Id).ToArray();
            return Page();
        }




        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var clienteToUpdate = await _context.Clientes.Include(c => c.Projetos).FirstOrDefaultAsync(c => c.Id == id);

            if (clienteToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<ClienteModel>(
                clienteToUpdate,
                "ClienteModel",
                c => c.Nome, c => c.Email, c => c.Telefone))
            {
                // Atualização dos projetos associados será tratada aqui
                // Por enquanto, esse código apenas atualiza as propriedades básicas do ClienteModel

                await _context.SaveChangesAsync();
                return RedirectToPage("/Clientes/Index");
            }

            return Page();
        }
    }
}
