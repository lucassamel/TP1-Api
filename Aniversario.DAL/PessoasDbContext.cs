using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Aniversario.BLL.Models;

namespace Aniversario.DAL
{
    class PessoasDbContext : DbContext
    {
        public PessoasDbContext(DbContextOption<PessoasDbContext> options) : base(options) { }
        
            public virtual DbSet<Pessoa> Pessoas { get; set; }
        
    }
}
