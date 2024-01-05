using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WriteMore.Application.DTOs.Response
{
    public class LoginUserResponse
    {
        public bool Success => Errors.Count == 0;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string AccessToken { get; private set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string RefreshToken { get; private set; }

        public List<string> Errors { get; private set; }

        public LoginUserResponse()
        {
            Errors = new List<string>();
        }

        public LoginUserResponse(bool success, string accessToken, string refreshToken): this()
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }

        public void AddErrors(string error)
        {
            Errors.Add(error);
        }

        public void AddErrors(IEnumerable<string> errors) {
            Errors.AddRange(errors);
        }
    }
}
