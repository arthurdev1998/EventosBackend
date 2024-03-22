using Microsoft.EntityFrameworkCore;
using ProEvento.models;

namespace ProEvento.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Evento> Evento { get; set; }
    public DbSet<Lote> Lotes { get; set; }
    public DbSet<Palestrante> Palestrantes { get; set; }
    public DbSet<RedeSocial> RedeSocials { get; set; }


    // protected override void OnModelCreating(ModelBuilder builder)
    // {
    //     base.OnModelCreating(builder);

    //     builder.Entity<UserRole>(options =>
    //     {
    //         options.HasKey(x => new { x.UserId, x.RoleId });
    //         options.HasOne(X => X.Role)
    //                 .WithMany(e => e.UserRoles)
    //                 .HasForeignKey(x => x.RoleId)
    //                 .IsRequired();


    //         options.HasOne(X => X.User)
    //                 .WithMany(e => e.UserRoles)
    //                 .HasForeignKey(x => x.UserId)
    //                 .IsRequired();
    //     });
};