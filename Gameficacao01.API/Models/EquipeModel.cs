using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gameficacao01.API.Models
{
    public class EquipeModel
    {
          [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } // Identificador único para a equipe

        public string Nome {get; set;}

        public string Descricao { get; set; }


        public int? ProjetoId { get; set; }
        public ProjetoModel? Projeto { get; set; } // Usando singular pois cada equipe está associada a um projeto

    public ICollection<MembroModel> Membros { get; } = new List<MembroModel>(); // Collection navigation containing dependents

    }
}