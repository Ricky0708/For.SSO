using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace For.SSO.AuthenticationManager
{
    public class IdentityConfig : ClaimsIdentity
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

        public IdentityConfig(IEnumerable<Claim> claims, string authenticationType)
            : base(claims, authenticationType: authenticationType)
        {
        }

        public IdentityConfig(IEnumerable<string> groups, string UserNo, int UserId, string UserName)
        {
            AddClaims(from @group in groups select new Claim(GroupsClaimType, @group));
            AddClaim(new Claim(UserIdClaimType, UserId.ToString()));
            AddClaim(new Claim(UserNameClaimType, UserName.ToString()));
        }


        public IEnumerable<string> Groups { get { return from claim in FindAll(GroupsClaimType) select claim.Value; } }

        public string UserId { get { return FindFirst(UserIdClaimType).Value; } }
        public string UserName { get { return FindFirst(UserNameClaimType).Value; } }
    }
}
