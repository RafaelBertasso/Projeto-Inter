using Microsoft.EntityFrameworkCore;
using ProjetoInter.Models;

public class ServiceDatabase : DbContext
{
    public ServiceDatabase(DbContextOptions options) : base(options) {}

    public DbSet<Service> Services{ get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserService> UserServices { get; set; }
}