using Microsoft.EntityFrameworkCore;
using Teledok.Models;

namespace Teledok.DAL;

public class ApiDbContext : DbContext
{
    public DbSet<Client> Clients { get; private set; }
    public DbSet<Founder> Founders { get; private set; }

    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
    {
	
	}

    public ApiDbContext()
    { 

    }

    
}

