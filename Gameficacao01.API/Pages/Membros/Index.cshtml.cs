using Gameficacao01.API.Data;
using Gameficacao01.API.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;  // <-- Adicione esta linha
using System.Collections.Generic;
using System.Linq;

namespace Gameficacao01.API.Pages.Membros
{
    public class Index : PageModel
    {
        private readonly AppDbContext _context;

        public Index(AppDbContext context)
        {
            _context = context;
        }

        public IList<MembroModel> Membros { get; set; }

        public void OnGet()
        {
            Membros = _context.Membros.Include(m => m.Equipes).ToList();
        }
    }
}
