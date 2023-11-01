using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gameficacao01.API.Models
{
    public class MembroModel
    {
  [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; } 
    public string Nome { get; set; } 
    public string Papel { get; set; } 

    public int? EquipeId { get; set; } 
    public EquipeModel? Equipes { get; set; }

    
    }
}