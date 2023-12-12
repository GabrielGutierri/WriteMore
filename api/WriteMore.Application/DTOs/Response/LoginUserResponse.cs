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
        public bool Success { get; private set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Token { get; private set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateTime? ExpireDate { get; private set; }

        public List<string> Errors { get; private set; }

        public LoginUserResponse()
        {
            Errors = new List<string>();
        }

        public LoginUserResponse(bool success = true): this()
        {
            Success = success;
        }
        public LoginUserResponse(bool success, string token, DateTime expireDate): this(success)
        {
            Token = token;
            ExpireDate = expireDate;
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
