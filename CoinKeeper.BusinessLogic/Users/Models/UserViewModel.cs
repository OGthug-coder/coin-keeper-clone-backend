namespace Domain.Entities.Users;

public class UserViewModel
{
    public UserViewModel(User user)
    {
        Name = user.Name;
        Email = user.Email;
    }
    
    public string Name { get; set; }
    public string Email { get; set; }
}