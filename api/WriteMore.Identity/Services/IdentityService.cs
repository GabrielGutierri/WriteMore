using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WriteMore.Application.DTOs.Request;
using WriteMore.Application.DTOs.Response;
using WriteMore.Application.Interfaces.Services;
using WriteMore.Identity.Configurations;

namespace WriteMore.Identity.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly JwtOptions _jwtOptions;

        public IdentityService(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, IOptions<JwtOptions> jwtOptions)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _jwtOptions = (JwtOptions?)jwtOptions;
        }
        public async Task<LoginUserResponse> Login(LoginUserRequest loginRequest)
        {
            var result = await _signInManager.PasswordSignInAsync(loginRequest.Email, loginRequest.Password, false, false);
            if (result.Succeeded)
                return await GenerateToken(loginRequest.Email);
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

        private async Task<LoginUserResponse> GenerateToken(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var tokenClaims = await GetClaims(user);
            var expireDate = DateTime.Now.AddSeconds(_jwtOptions.ExpireDate);
            var jwt = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                claims: tokenClaims,
                notBefore: DateTime.Now,
                expires: expireDate,
                signingCredentials: _jwtOptions.SigningCredentials
                );
            var token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new LoginUserResponse(success: true, token, expireDate);
        }

        private async Task<IList<Claim>> GetClaims(IdentityUser user)
        {
            var claims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, DateTime.Now.ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()));
            
            foreach(var role in roles)
            {
                claims.Add(new Claim("role", role));
            }
            return claims;
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
