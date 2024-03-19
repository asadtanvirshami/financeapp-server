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

app
.MapPut("/users/{id}",(int id, UpdateUserDto updateUser)=>{
 var index = users.FindIndex(user=> user.Id == id);
 users[index] = new FinanceDto(
    id,
    updateUser.Username,
    updateUser.Name,
    updateUser.Password
 );
 return Results.NoContent();
});

app.MapDelete("/users/{id}",(int id)=>{
 users.RemoveAll(user=> user.Id == id);

 return Results.NoContent();
});

app.Run();
