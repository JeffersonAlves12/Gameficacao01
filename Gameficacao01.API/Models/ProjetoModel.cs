using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Gameficacao01.API.Models
{
    public class ProjetoModel
    {
         [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataConclusaoPrevista { get; set; }
        public string Status { get; set; }

        public ICollection<TarefaModel> Tarefas { get; } = new List<TarefaModel>();
        public EquipeModel? Equipe { get; set; } 

        public int? EquipeId { get; set; } 

        public int? ClienteId { get; set; } 
        public ClienteModel? Clientes { get; set; } 

    }
}