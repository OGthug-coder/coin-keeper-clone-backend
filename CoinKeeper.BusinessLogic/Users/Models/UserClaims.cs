namespace Domain.Entities.Users;

public class UserClaims
{
    public IEnumerable<ClaimViewModel> Claims { get; set; }
    public string UserName { get; set; }
}