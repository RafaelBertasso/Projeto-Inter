using Microsoft.EntityFrameworkCore;
using ProjetoInter.Models;

public class ServiceDatabase : DbContext
{
    public ServiceDatabase(DbContextOptions options) : base(options) { }

    public DbSet<Service> Services { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserService> UserServices { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Employee> Employees { get; set; }

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     base.OnModelCreating(modelBuilder);

    //     // Configuração da herança entre User, Client e Employee
    //     modelBuilder.Entity<Client>()
    //         .HasBaseType<User>();

    //     modelBuilder.Entity<Employee>()
    //         .HasBaseType<User>();

    //     // Configuração da associação muitos-para-muitos entre Services e Clients sem navegações
    //     modelBuilder.Entity<Client>()
    //         .HasMany<Service>()
    //         .WithMany()
    //         .UsingEntity<Dictionary<string, object>>(
    //             "UserService", // Nome da tabela de junção
    //             j => j.HasOne<Service>().WithMany().HasForeignKey("ServiceId").OnDelete(DeleteBehavior.NoAction),
    //             j => j.HasOne<Client>().WithMany().HasForeignKey("ClientId").OnDelete(DeleteBehavior.NoAction));
    // }
}