using Microsoft.EntityFrameworkCore;
using ProjetoInter.Models;

public class ServiceDatabase : DbContext
{
    public ServiceDatabase(DbContextOptions<ServiceDatabase> options) : base(options) { }

    public DbSet<Service> Services { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<ClientService> ClientServices { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Employee> Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}