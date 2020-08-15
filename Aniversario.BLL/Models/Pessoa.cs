using System;
using System.Collections.Generic;
using System.Text;

namespace Aniversario.BLL.Models
{
    class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime Aniversario { get; set; }
    }
}
