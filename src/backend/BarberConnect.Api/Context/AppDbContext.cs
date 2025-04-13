using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BarberConnect.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace BarberConnect.Api.Context
{
    public class AppDbContext : DbContext
    {
         //construtor
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        //mapeamento
        public DbSet<Cliente>? Clientes { get; set; }
        // public DbSet<ServicoModel>? Servicos { get; set; }
    }
}
