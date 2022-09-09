using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Shared.PaximumModels
{
    public class AuthenticationRequest
    {
        public string Agency { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
    }
}
