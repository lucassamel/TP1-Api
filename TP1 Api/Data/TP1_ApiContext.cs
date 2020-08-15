using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pessoa.Models;

namespace TP1_Api.Data
{
    public class TP1_ApiContext : DbContext
    {
        public TP1_ApiContext (DbContextOptions<TP1_ApiContext> options)
            : base(options)
        {
        }

        public DbSet<Pessoa.Models.Pessoa> Pessoa { get; set; }
    }
}
