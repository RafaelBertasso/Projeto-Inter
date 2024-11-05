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


        // modelBuilder.Entity<Client>()
        //     .HasOne<User>(e => e.UserId)
        //     .WithOne(e => e.UserId)
        //     .OnDelete(DeleteBehavior.Restrict);
        //     // Configuração da herança entre User, Client e Employee
        //     modelBuilder.Entity<Client>()

        //                 // .HasOne("ProjetoInter.Models.User", null)
        //                 //     .WithOne()
        //                 //     .HasForeignKey("ProjetoInter.Models.Client", "UserId")
        //                 //     .OnDelete(DeleteBehavior.NoAction)
        //                 //     .IsRequired();

        //                 .HasOne("ProjetoInter.Models.User", "User")
        //                     .WithMany()
        //                     .HasForeignKey("UserId1")
        //                     .OnDelete(DeleteBehavior.NoAction)
        //                     .IsRequired();

        //     modelBuilder.Entity<Employee>()
        //         .HasBaseType<User>();

        //     // Configuração da associação muitos-para-muitos entre Services e Clients sem navegações
        //     modelBuilder.Entity<Client>()
        //         .HasMany<Service>()
        //         .WithMany()
        //         .UsingEntity<Dictionary<string, object>>(
        //             "UserService", // Nome da tabela de junção
        //             j => j.HasOne<Service>().WithMany().HasForeignKey("ServiceId").OnDelete(DeleteBehavior.NoAction));
        //             //j => j.HasOne<Client>().WithMany().HasForeignKey("UserId").OnDelete(DeleteBehavior.NoAction));
         }
    }