using SERVER_FINANCE.API.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

const string GetUserEndPointName = "GetUser";

List<FinanceDto> users = [
new (
    1,
    "asad",
    "asad@gmail",
    "123"
 ),
new (
    2,
    "hammad",
    "hammad@gmail",
    "1233"
 ),
];

app.MapGet("/users", () => users);
app
.MapGet("/users/{id}", (int id) => users.Find(user => user.Id == id))
.WithName(GetUserEndPointName);

app
.MapPost("/users",(CreateUserDto newUser)=>
{
   FinanceDto user = new(
    users.Count + 1,
    newUser.Name,
    newUser.Username,
    newUser.Password
   );  
    users.Add(user);
    return Results.CreatedAtRoute(GetUserEndPointName, new{id = user.Id}, user);

} );

app.Run();
