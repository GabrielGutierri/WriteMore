using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WriteMore.Application.DTOs.Response
{
    public class RegisterUserResponse
    {
        public bool Success { get; private set; }
        public List<string> Errors { get; private set; }

        public RegisterUserResponse()
        {
            Errors = new List<string>();
        }

        public RegisterUserResponse(bool success = true) : this()
        {
            Success = success;
        }

        public void AddErrors(IEnumerable<string> errors)
        {
            Errors.AddRange(errors);
        }
    }
}
