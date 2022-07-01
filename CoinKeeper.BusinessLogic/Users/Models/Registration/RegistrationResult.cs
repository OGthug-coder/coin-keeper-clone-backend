using System.Text.Json.Serialization;

namespace Domain.Entities.Users.Registration;

public class RegistrationResult
{
    [JsonPropertyName("Status")]
    public RegistrationStatus Status { get; set; }
    
    [JsonPropertyName("Message")]
    public string Message { get; set; } = null!;

    [JsonPropertyName("Errors")]
    public IEnumerable<string> Errors { get; set; } = null!;

    [JsonPropertyName("Data")]
    public UserViewModel Data { get; set; } = null!;
}