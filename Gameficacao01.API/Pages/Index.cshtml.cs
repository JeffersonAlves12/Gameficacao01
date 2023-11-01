using System.Linq;
using Gameficacao01.API.Data;
using Gameficacao01.API.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Gameficacao01.API.Pages
{
    public class Index : PageModel
    {
        private readonly AppDbContext _context;

        public Index(AppDbContext context)
        {
            _context = context;
        }

        public int TotalProjetos { get; set; }
        public int TotalSprints { get; set; }
        public int TotalEquipes { get; set; }
        public double PercentualProjetosConcluidos { get; set; }
        public double PercentualProjetosEmAndamento { get; set; }
        public double PercentualProjetosPendentes { get; set; }

        public void OnGet()
        {
            TotalProjetos = _context.Set<ProjetoModel>().Count();
            TotalSprints = _context.Set<SprintModel>().Count();
            TotalEquipes = _context.Set<EquipeModel>().Count();

            var projetosConcluidos = _context.Set<ProjetoModel>().Count(p => p.Status == "Concluído");
            var projetosEmAndamento = _context.Set<ProjetoModel>().Count(p => p.Status == "Em Andamento");
            var projetosPendentes = _context.Set<ProjetoModel>().Count(p => p.Status == "Pendente");

            if (TotalProjetos > 0)
            {
                PercentualProjetosConcluidos = ((double)projetosConcluidos / TotalProjetos) * 100;
                PercentualProjetosEmAndamento = ((double)projetosEmAndamento / TotalProjetos) * 100;
                PercentualProjetosPendentes = ((double)projetosPendentes / TotalProjetos) * 100;
            }
        }
    }
}
