namespace SERVER_FINANCE.API.Dtos;

public record class UpdateUserDto(
    string Name,
    string Username,
    string Password
);