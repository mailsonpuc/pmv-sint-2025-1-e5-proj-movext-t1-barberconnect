
# dotnet add package Microsoft.EntityFrameworkCore.InMemory
# dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
# dotnet add package Microsoft.EntityFrameworkCore.Design
# dotnet add package Microsoft.EntityFrameworkCore.SqlServer
# dotnet add package Microsoft.EntityFrameworkCore.Tools



dotnet aspnet-codegenerator controller \
-name AvaliacaosController             \
-async -api                            \
-m Avaliacao                           \
-dc AppDbContext                       \
-outDir Controllers


dotnet aspnet-codegenerator controller \
-name BarbeirosController              \
-async -api                            \
-m Barbeiro                            \
-dc AppDbContext                       \
-outDir Controllers


dotnet aspnet-codegenerator controller \
-name ClientesController               \
-async -api                            \
-m Cliente                             \
-dc AppDbContext                       \
-outDir Controllers


dotnet aspnet-codegenerator controller \
-name HistoricoCortesController        \
-async -api                            \
-m HistoricoCorte                      \
-dc AppDbContext                       \
-outDir Controllers

dotnet aspnet-codegenerator controller \
-name HorarioDisponivelsController     \
-async -api                            \
-m HorarioDisponivel                   \
-dc AppDbContext                       \
-outDir Controllers


dotnet aspnet-codegenerator controller \
-name ServicosController               \
-async -api                            \
-m Servico                             \
-dc AppDbContext                       \
-outDir Controllers