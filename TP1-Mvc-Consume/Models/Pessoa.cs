using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TP1_Mvc_Consume.Models
{
    public class Pessoa
    {
        public int PessoaId { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime Aniversario { get; set; }
    }
}
