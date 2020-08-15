using System;
using System.Collections.Generic;
using System.Text;

namespace PessoaDL
{
    public class PessoaContext
    {
        public PessoaDbContext(DbContextOptions<PessoaDbContext> options) : base(options)
        {

        }
    }
}
