using System.ComponentModel.DataAnnotations;

namespace User.API.Dtos;

public record class CreateUserDto(
    [Required][StringLength(10)] string Name,
    [Required][StringLength(5)]string Username,
    [Required][StringLength(8)]string Password
);