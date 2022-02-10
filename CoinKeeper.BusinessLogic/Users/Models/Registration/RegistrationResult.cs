namespace Domain.Entities.Users.Registration;

public class RegistrationResult
{
    public RegistrationStatus Status { get; set; }
    public string Message { get; set; }
    public IEnumerable<string> Errors { get; set; }
    public UserViewModel Data { get; set; }
}