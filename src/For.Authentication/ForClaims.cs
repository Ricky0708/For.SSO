using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace For.Authentication
{
    public class ForClaims : ClaimsIdentity
    {
        public const string GroupsClaimType = "Security.Group";
        public const string UserIdClaimType = "Security.Id";
        public const string UserNameClaimType = "Security.UserName";
        public const string ProgramsClaimType = "Security.Program";
        public const string ExternalCookie = "ExternalCookie";

        public override string Name
        {
            get
            {
                return FindFirst(UserNameClaimType).Value;
            }
        }

        public ForClaims(IEnumerable<Claim> claims, string authenticationType)
            : base(claims, authenticationType: authenticationType)
        {
        }

        public IEnumerable<string> Groups { get { return from claim in FindAll(GroupsClaimType) select claim.Value; } }

        public string UserId { get { return FindFirst(UserIdClaimType).Value; } }

        public string UserName { get { return FindFirst(UserNameClaimType).Value; } }
    }
}
