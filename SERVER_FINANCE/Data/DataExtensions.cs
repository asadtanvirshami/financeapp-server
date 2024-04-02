using FinanceServer.API.Data;
using Microsoft.EntityFrameworkCore;

namespace FinanceStore.API.Data;

public static class DataExtensions
{
    public static void MigrateDb(this WebApplication app){
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<FinanceStoreContext>();
        dbContext.Database.Migrate();
    }
}