using Microsoft.EntityFrameworkCore;
using WebApiRouteResponses.Models;

namespace WebApiRouteResponses.Context;

public class ApiDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        List<User> userDataInitializer =
    [
        new() { Name = "Juan", LastName = "Julio", Age = 23 },
        new() { Name = "Vero", LastName = "Vera", Age = 22 },
        new() { Name = "Yamileth", LastName = "Valdiviezo", Age = 23 }
    ];

        modelBuilder.Entity<User>().ToTable("User").HasData(userDataInitializer);
        modelBuilder.Entity<User>().HasKey(p => p.Id);

        List<UserRole> userRoleData =
    [
        new() { Role = "Admin", UserId = userDataInitializer[0].Id },
        new() { Role = "User", UserId = userDataInitializer[1].Id },
        new() { Role = "Support", UserId = userDataInitializer[2].Id }
    ];

        modelBuilder.Entity<UserRole>().ToTable("UserRole").HasData(userRoleData);
        modelBuilder.Entity<UserRole>().HasKey(p => p.Id);
        
        // Configuración correcta de la relación uno a muchos
        modelBuilder.Entity<UserRole>()
            .HasOne(u => u.User)                // UserRole tiene un User
            .WithMany(u => u.UserRoles)         // User tiene muchos UserRoles
            .HasForeignKey(ur => ur.UserId);    // La clave foránea es UserId
    }
}
