using Microsoft.EntityFrameworkCore
using FinanceServer.API.Entities;

namespace FinanceServer.API.Data;

public class FinanceStoreContext(DbContextOptions<FinanceStoreContext> options)
: DbContext(options)
{
    public DbSet<Users> User => Set<Users>();
    public DbSet<Sales> Sale => Set<Sales>();
}