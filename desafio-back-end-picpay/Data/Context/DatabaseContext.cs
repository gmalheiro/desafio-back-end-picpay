using desafio_back_end_picpay.Models;
using Microsoft.EntityFrameworkCore;

namespace desafio_back_end_picpay.Data.Context;

public class DatabaseContext : DbContext
{
    public DatabaseContext()
    {
        
    }

    public DatabaseContext(DbContextOptions <DatabaseContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
}
