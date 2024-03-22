using User.API.Dtos;

namespace User.API.Endpoints;
public static class UserEndpoints
{
    const string GetUserEndPointName = "GetUser";
    private static readonly List<UserDto> users = [
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
    public static RouteGroupBuilder MapUsersEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("users");

        group.MapGet("/", () => users);

        group
        .MapGet("/{id}", (int id) =>
        {
            UserDto? user =
           users.Find(user => user.Id == id);
            return user is null ? Results.NotFound() : Results.Ok(user);
        })
        .WithName(GetUserEndPointName);

        group
        .MapPost("/", (CreateUserDto newUser) =>
        {
            UserDto user = new(
            users.Count + 1,
            newUser.Name,
            newUser.Username,
            newUser.Password
          );
            users.Add(user);
            return Results.CreatedAtRoute(GetUserEndPointName, new { id = user.Id }, user);

        }).WithParameterValidation();

        group
        .MapPut("/{id}", (int id, UpdateUserDto updateUser) =>
        {
            var index = users.FindIndex(user => user.Id == id);
            if (index == -1)
            {
                return Results.NotFound();
            }
            users[index] = new UserDto(
       id,
       updateUser.Username,
       updateUser.Name,
       updateUser.Password
    );
            return Results.NoContent();
        });

        group.MapDelete("/{id}", (int id) =>
        {
            users.RemoveAll(user => user.Id == id);

            return Results.NoContent();
        });

        return group;
    }
};