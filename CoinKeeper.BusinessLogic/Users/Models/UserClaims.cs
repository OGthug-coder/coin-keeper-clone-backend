namespace Domain.Entities.Users;

public class UserClaims
{
    public IEnumerable<ClaimViewModel> Claims { get; set; } = null!;
    public string UserName { get; set; } = null!;
}