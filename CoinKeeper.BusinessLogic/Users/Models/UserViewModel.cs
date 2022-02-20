using System.Text.Json.Serialization;

namespace Domain.Entities.Users;

public class UserViewModel
{
    public UserViewModel(User user)
    {
        Name = user.Name;
        Email = user.Email;
    }
    
    [JsonPropertyName("Name")]
    public string Name { get; set; }
    
    [JsonPropertyName("Email")]
    public string Email { get; set; }
}