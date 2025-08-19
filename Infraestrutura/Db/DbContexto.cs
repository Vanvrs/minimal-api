using Microsoft.EntityFrameworkCore;
using minimal_api.Dominio.Entidades;
using Microsoft.Extensions.Configuration;

namespace Minimal.Infraestrutura.Db;

public class DbContexto : DbContext
{
    private readonly IConfiguration _configurationAppString;
    public DbContexto(IConfiguration configurationAppString)
    {
        _configurationAppString = configurationAppString;
    }

    public DbSet<Administrador> Administradores { get; set; } = default!;
    public DbSet<Veiculo> Veiculos { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Administrador>().HasData(
            new Administrador
            {
                Id = 1,
                Email = "administrador@teste.com",
                Senha = "123456",
                Perfil = "Adm"
            }

        );
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            // Configuração para design-time (migrations)
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = _configurationAppString.GetConnectionString("MySql")?.ToString();

            if (!string.IsNullOrEmpty(connectionString))
            {
                optionsBuilder.UseMySql(
                    connectionString,
                    ServerVersion.AutoDetect(connectionString)
                );
            }
            else
            {
                throw new InvalidOperationException("String de conexão 'mysql' não encontrada ou vazia.");
            }
        }
    }
}