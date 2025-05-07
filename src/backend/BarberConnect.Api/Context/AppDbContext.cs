

using BarberConnect.Api.Models;
using Microsoft.EntityFrameworkCore;
// using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BarberConnect.Api.Context
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        // Construtor
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }


        // Mapeamento
        public DbSet<Agendamento> Agendamentos { get; set; }
        public DbSet<Avaliacao> Avaliacoes { get; set; }
        public DbSet<Barbeiro> Barbeiros { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<HistoricoCorte> HistoricoCortes { get; set; }
        public DbSet<HorarioDisponivel> HorarioDisponiveis { get; set; }
        public DbSet<Servico> Servicos { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Cliente - Agendamento (1:N)
            modelBuilder.Entity<Agendamento>()
                .HasOne(a => a.Cliente)
                .WithMany(c => c.Agendamentos)
                .HasForeignKey(a => a.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);

            // Agendamento - Servico (1:1)
            modelBuilder.Entity<Agendamento>()
                .HasOne(a => a.Servico)
                .WithMany()
                .HasForeignKey(a => a.ServicoId)
                .OnDelete(DeleteBehavior.Restrict);

            // Agendamento - HorarioDisponivel (1:1)
            modelBuilder.Entity<Agendamento>()
                .HasOne(a => a.Horario)
                .WithMany()
                .HasForeignKey(a => a.HorarioId)
                .OnDelete(DeleteBehavior.Restrict);

            // HorarioDisponivel - Barbeiro (1:N)
            modelBuilder.Entity<HorarioDisponivel>()
                .HasOne(h => h.Barbeiro)
                .WithMany()
                .HasForeignKey(h => h.BarbeiroId)
                .OnDelete(DeleteBehavior.Restrict);

            // HistoricoCorte - Agendamento (1:1)
            modelBuilder.Entity<HistoricoCorte>()
                .HasOne(h => h.Agendamento)
                .WithMany()
                .HasForeignKey(h => h.AgendamentoId)
                .OnDelete(DeleteBehavior.Restrict);

            // Avaliacao - Agendamento (1:1 ou N:1)
            modelBuilder.Entity<Avaliacao>()
                .HasOne(a => a.Agendamento)
                .WithMany()
                .HasForeignKey(a => a.AgendamentoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Barbeiro>()
               .HasMany(b => b.Servicos)
               .WithMany(s => s.Barbeiros);


            // Avaliacao - Cliente (opcional ou com FK se ClienteId existir)
            modelBuilder.Entity<Avaliacao>()
                .HasOne(a => a.Cliente)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);


            // avaliacao
            modelBuilder.Entity<Avaliacao>()
                .HasOne(a => a.Barbeiro)
                .WithMany()
                .HasForeignKey(a => a.BarbeiroId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Avaliacao>()
                .HasOne(a => a.Cliente)
                .WithMany()
                .HasForeignKey(a => a.ClienteId) //  ClienteId
                .OnDelete(DeleteBehavior.Restrict);


        }




    }

}

