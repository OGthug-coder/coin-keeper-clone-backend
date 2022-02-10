using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Users.Registration;

public class RegisterModel
{
    public string Name { get; set; }
    
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
    
    [DataType(DataType.Password)]
    public string Password { get; set; }
    
    [Compare("Password")]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; }
}