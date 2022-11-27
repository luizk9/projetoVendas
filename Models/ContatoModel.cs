using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace projContato.Models
{
    public class ContatoModel
    {
        
        public int Id {get; set;}

        [Required(ErrorMessage = "Digite o nome do Contato")]
        public string Nome {get; set;}

        [Required(ErrorMessage = "Digite o  Local")] 
        public string Local {get; set;}

        [Required(ErrorMessage = "Digite o Valor total")]        
        public string ValorTotal {get; set;}
    }
}

// [EmailAddress(ErrorMessage = "Digite o Email do Contato")]
// [Phone(ErrorMessage = "Digite o telefone do Contato")]