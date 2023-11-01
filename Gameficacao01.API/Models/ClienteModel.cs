using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Gameficacao01.API.Models
{
    public class ClienteModel
    {
      // Propriedades
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 
        public string Nome { get; set; }
        public string? Email { get; set; } 
        public string? Telefone { get; set; } 
        public ICollection<ProjetoModel> Projetos { get; } = new List<ProjetoModel>(); 

        // Construtor
        public ClienteModel()
        {
            // Valores padrão ou inicialização, se necessário
        }

        // Métodos (se você precisar adicionar funcionalidades específicas para um cliente)
        public string ObterInformacoesDeContato()
        {
            return $"Email: {Email}, Telefone: {Telefone}";
        }     
    }
}