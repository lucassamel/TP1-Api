using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using PessoaBL.Models;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace PessoaDL
{
    public class PessoaDbContext : DbContext
    {
        public PessoaDbContext(DbContextOptions<PessoaDbContext> options) : base(options)
        {

        }
            public virtual DbSet<Pessoa> Pessoas { get; set; }
        
        public class DesingTimeDbContextFactory : IDesignTimeDbContextFactory<PessoaDbContext>
        {
            public PessoaDbContext CreateDbContext(string[] args)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(@Directory.GetCurrentDirectory() + "/../TP1/appsettings.json").Build();

                var builder = new DbContextOptionsBuilder<PessoaDbContext>();
                var connectionString = configuration.GetConnectionString("DatabaseConnection");
                builder.UseSqlServer(connectionString);

                return new PessoaDbContext(builder.Options);
            }
        }
    }
}
