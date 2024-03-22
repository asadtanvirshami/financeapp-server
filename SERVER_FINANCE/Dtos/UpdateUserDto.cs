namespace User.API.Dtos;

public record class UpdateUserDto(
    string Name,
    string Username,
    string Password,
    decimal GPA
);