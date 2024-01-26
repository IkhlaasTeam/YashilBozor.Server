using Microsoft.EntityFrameworkCore;
using YashilBozor.Domain.Entities.Categories;
using YashilBozor.Domain.Entities.Users;
using YashilBozor.Domain.Entities.Users.Auth;

namespace YashilBozor.DAL.DbContexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
                : base(options) { }

    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Commentary> Commentaries { get; set; }
    public DbSet<AccessToken> AccessTokens { get; set; }
    public DbSet<Category> ProductCategories { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<UserCreadentials> UserCredentials { get; set; }
    public DbSet<VerificationCode> VerificationCodes { get; set; }
    public DbSet<UserInfoVerificationCode> UserInfoVerificationCodes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    { }
}
