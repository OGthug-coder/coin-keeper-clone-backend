using System.Text.Json.Serialization;

namespace Domain.Entities.Users;

public class UserStateViewModel
{
    [JsonPropertyName("IsAuthenticated")]
    public bool IsAuthenticated { get; set; }
    
    [JsonPropertyName("UserName")]
    public string UserName { get; set; }
}