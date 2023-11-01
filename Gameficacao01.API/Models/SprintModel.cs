using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gameficacao01.API.Models
{
    public class SprintModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataTermino { get; set; }
    public string Nome { get; set; }
    
    // Relacionamento de um para muitos com Tarefa
    public ICollection<TarefaModel> Tarefas { get; } = new List<TarefaModel>(); // Collection navigation containing dependents
    
    }
}