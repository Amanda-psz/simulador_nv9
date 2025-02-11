using Microsoft.EntityFrameworkCore;
using sistemaGestaoPizzaria.domain;

namespace sistemaGestaoPizzaria.infra
{
    public class ConnectionContext : DbContext
    {
        public DbSet<Produto> Produto { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
              "Server=localhost;" +
                "Port=3306;" +
                "Database=sistema_gestao_pizzaria;" +
                 "User Id=root;" +
                "Password=Pr0gr@25;",
                new MySqlServerVersion(new Version(8, 0, 3)));
        }
    }
}
