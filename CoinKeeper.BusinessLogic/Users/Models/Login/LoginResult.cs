using Domain.Entities.Users;

namespace CoinKeeper.BusinessLogic.Users.Models;

public class LoginResult
{
    public LoginStatus Status { get; set; }
    public string Message { get; set; }
    public IEnumerable<string> Errors { get; set; }
    public UserViewModel Data { get; set; }
}