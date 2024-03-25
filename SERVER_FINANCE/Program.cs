using FinanceServer.API.Data;
using User.API.Endpoints;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var connString = builder.Configuration.GetConnectionString("Finance");
builder.Services.AddSqlite<FinanceStoreContext>(connString);
app.MapUsersEndpoints();

app.Run();
