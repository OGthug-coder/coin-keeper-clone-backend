using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Users.Registration;

public class RegisterModel
{
    public string Name { get; set; } = null!;

    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;

    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    [Compare("Password")]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; } = null!;
}