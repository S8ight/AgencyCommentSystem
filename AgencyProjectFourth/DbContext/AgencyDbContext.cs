using AgencyProjectFourth.Models;
using Microsoft.EntityFrameworkCore;

namespace AgencyProjectFourth.DbContext;

public class AgencyDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public DbSet<Comment> Comments { get; set; }
    
    public AgencyDbContext(DbContextOptions options) : base(options)
    {
    }
}