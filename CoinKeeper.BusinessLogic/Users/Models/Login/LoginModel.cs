using System.ComponentModel.DataAnnotations;

namespace CoinKeeper.BusinessLogic.Users.Models;

public class LoginModel
{
    public string UserName { get; set; } = null!;

    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;
}