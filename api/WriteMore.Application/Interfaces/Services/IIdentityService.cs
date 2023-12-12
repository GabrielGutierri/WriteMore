using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WriteMore.Application.DTOs.Request;
using WriteMore.Application.DTOs.Response;

namespace WriteMore.Application.Interfaces.Services
{
    public interface IIdentityService
    {
        Task<RegisterUserResponse> RegisterUser(RegisterUserRequest registerRequest);

        Task<LoginUserResponse> Login(LoginUserRequest loginRequest);
    }
}
