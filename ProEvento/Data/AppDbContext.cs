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
}