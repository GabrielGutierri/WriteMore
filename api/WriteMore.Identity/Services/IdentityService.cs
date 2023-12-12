using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WriteMore.Application.DTOs.Request;
using WriteMore.Application.DTOs.Response;
using WriteMore.Application.Interfaces.Services;

namespace WriteMore.Identity.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly JwtBearerOptions _jwtOptions;

        public IdentityService(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, IOptions<JwtBearerOptions> jwtOptions)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _jwtOptions = (JwtBearerOptions?)jwtOptions;
        }
        public async Task<LoginUserResponse> Login(LoginUserRequest loginRequest)
        {
            var result = await _signInManager.PasswordSignInAsync(loginRequest.Email, loginRequest.Password, false, false);
            //TO DO: ADD MFA
            var loginResponse = new LoginUserResponse(result.Succeeded);
            if(!result.Succeeded)
            {
                if (result.IsLockedOut)
                    loginResponse.AddErrors("User locked...");
                else if (result.IsNotAllowed)
                    loginResponse.AddErrors("User not allowed...");
                else if (result.RequiresTwoFactor)
                    loginResponse.AddErrors("User needs to confirm the login...");
                else
                    loginResponse.AddErrors("Invalid email or password");
            }
            return loginResponse;
        }

        public async Task<RegisterUserResponse> RegisterUser(RegisterUserRequest registerRequest)
        {
            var identityUser = new IdentityUser
            {
                UserName = registerRequest.Email,
                Email = registerRequest.Email,
                EmailConfirmed = true
            };
            //TO DO : send email to confirm user's email
            var result = await _userManager.CreateAsync(identityUser, registerRequest.Password);
            if(result.Succeeded)
            {
                await _userManager.SetLockoutEnabledAsync(identityUser, false); //user is enabled to enter in the system
            }
            var userRegisterResponse = new RegisterUserResponse(result.Succeeded);
            if (!result.Succeeded && result.Errors.Count() > 0)
                userRegisterResponse.AddErrors(result.Errors.Select(e => e.Description));
            return userRegisterResponse;
        }
    }
}
