using System.Security.Claims;
using CoinKeeper.BusinessLogic.Users.Models;
using Domain.Entities.Users;
using Domain.Entities.Users.Registration;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
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
                        Data = new UserViewModel(user)
                    };
                }
                else
                {
                    errors.AddRange(result.Errors.Select(x => x.Description));
                }
            }
            else
            {
                errors.AddRange(ModelState.Keys.Select(x => x));                
            }

            return new RegistrationResult()
            {
                Status = RegistrationStatus.Error,
                Message = "Invalid data",
                Errors = errors
            };
        }

        [HttpPost]
        public async Task<LoginResult> Login([FromBody] LoginModel model)
        {
            var errors = new List<string>();
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.UserName);

                if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
                {
                    var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                    identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
                    identity.AddClaim(new Claim(ClaimTypes.Name, user.Name));

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(identity));
                    
                    return new LoginResult
                    {
                        Status = LoginStatus.Success,
                        Message = "Successful login",
                        Data = new UserViewModel(user)
                    };
                }
                else
                {
                    return new LoginResult
                    {
                        Status = LoginStatus.Error,
                        Message = "No user found or invalid password"
                    };
                }
                
            }
            else
            {
                errors.AddRange(ModelState.Keys.Select(x => x));
            }

            return new LoginResult
            {
                Status = LoginStatus.Error,
                Message = "Invalid data",
                Errors = errors
            };
        }
    }    
}
