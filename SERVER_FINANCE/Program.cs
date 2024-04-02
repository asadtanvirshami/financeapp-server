using FinanceServer.API.Data;
using FinanceStore.API.Data;
using User.API.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("Finance");
builder.Services.AddSqlite<FinanceStoreContext>(connString);

var app = builder.Build();
app.MapUsersEndpoints();

app.MigrateDb();

app.Run();
