namespace SERVER_FINANCE.API.Dtos;

public record class CreateUserDto(
    string Name,
    string Username,
    string Password
);