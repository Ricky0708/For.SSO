using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace For.SSO.AuthenticationManager
{
    public class SignInResult
    {
        public bool IsLockedOut { get; set; }
        public bool IsNotAllowed { get; set; }
        public bool RequiresTwoFactor { get; set; }
        public bool Succeeded { get; set; }

    }
}
