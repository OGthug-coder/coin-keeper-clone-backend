using System.Text.Json.Serialization;
using Domain.Entities.Users;

namespace CoinKeeper.BusinessLogic.Users.Models;

public class LoginResult
{
    [JsonPropertyName("Status")]
    public LoginStatus Status { get; set; }
    
    [JsonPropertyName("Message")]
    public string Message { get; set; } = null!;

    [JsonPropertyName("Errors")]
    public IEnumerable<string> Errors { get; set; } = null!;

    [JsonPropertyName("Data")]
    public UserViewModel Data { get; set; } = null!;
}