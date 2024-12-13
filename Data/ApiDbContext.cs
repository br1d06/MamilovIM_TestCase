using Microsoft.EntityFrameworkCore;
using Teledok.Models;

namespace Teledok.Data;

public class ApiDbContext : DbContext
{
    public virtual DbSet<Client> Clients { get; set; }
    public virtual DbSet<Founder> Founders { get; set; }

    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
    {
        
    }

	public ApiDbContext()
	{
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Founder>(entity =>
        {
            entity.HasOne(c => c.Client)
            .WithMany(f => f.Founders);
        });
    }
}

