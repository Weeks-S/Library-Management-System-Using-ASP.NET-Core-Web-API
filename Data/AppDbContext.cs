using BackendDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendDemo.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();
}
