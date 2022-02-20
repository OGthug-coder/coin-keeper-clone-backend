using System.Text.Json.Serialization;
using Domain.Entities.Users;

namespace CoinKeeper.BusinessLogic.Users.Models;

public class LoginResult
{
    [JsonPropertyName("Status")]
    public LoginStatus Status { get; set; }
    
    [JsonPropertyName("Message")]
    public string Message { get; set; }
    
    [JsonPropertyName("Errors")]
    public IEnumerable<string> Errors { get; set; }
    
    [JsonPropertyName("Data")]
    public UserViewModel Data { get; set; }
}