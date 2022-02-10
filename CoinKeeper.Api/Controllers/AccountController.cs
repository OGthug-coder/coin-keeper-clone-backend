using Domain.Entities.Users;
using Domain.Entities.Users.Registration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;

        public AccountController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<RegistrationResult> Register([FromBody] RegisterModel model)
        {
            var errors = new List<string>();
            if (ModelState.IsValid)
            {
                IdentityResult result = null;
                var user = await _userManager.FindByNameAsync(model.Name);

                if (user != null)
                {
                    return new RegistrationResult()
                    {
                        Status = RegistrationStatus.Error,
                        Message = "Invalid data",
                        Errors = new [] {"User already exists"}
                    };
                }
                
                user = new User(new Guid(), model.Name, model.Email);

                result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return new RegistrationResult()
                    {
                        Status = RegistrationStatus.Success,
                        Message = "User created",
                        Errors = Enumerable.Empty<string>(),
                        Data = user
                    };
                }
                else
                {
                    errors.AddRange(result.Errors.Select(x => x.Description));
                }
            }

            errors.AddRange(ModelState.Keys.Select(x => x));
            return new RegistrationResult()
            {
                Status = RegistrationStatus.Error,
                Message = "Invalid data",
                Errors = errors
            };
        }
    }    
}
