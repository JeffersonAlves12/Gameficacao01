using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gameficacao01.API.Models
{
    public class TarefaModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public string Status { get; set; }
    public string Responsavel { get; set; }
    public DateTime DataVencimento { get; set; }
    public int? SprintId { get; set; } 
    public SprintModel? Sprints { get; set; } 
        public int? ProjetoId { get; set; }
        public ProjetoModel? Projetos { get; set; }

    }
}