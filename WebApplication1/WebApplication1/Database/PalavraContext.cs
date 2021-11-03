using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Database
{
    public class PalavraContext : DbContext
    {

        public DbSet<Palavra> palavra { get; set; }
       public PalavraContext(DbContextOptions<PalavraContext> options) : base(options)
        {

        }

        public PalavraContext()
        {

        }
    }
}
