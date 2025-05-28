

using BarberConnect.Api.Context;
using BarberConnect.Api.Repositories;
using BarberConnect.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BarberConnect.Api.Test.Testes
{
    public class AgendamentoUnitTestController
    {
        public IUnitOfWork repository;
        public static DbContextOptions<AppDbContext> dbContextOptions { get; }

        public static string connectionString = "Server=localhost,1433;Database=ApiBarbeariaPuc;User ID=sa;Password=1q2w3e4r@#$;Trusted_Connection=False;TrustServerCertificate=True";


        static AgendamentoUnitTestController()
        {
            // Configurando as opções do DbContext com a string de conexão
            dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer(connectionString)
                .Options;
        }



        public AgendamentoUnitTestController()
        {
            var context = new AppDbContext(dbContextOptions);
            repository = new UnitOfWork(context);
        }

    }
}