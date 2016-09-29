using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace For.Authentication
{
    public class IdentityPrincipal : ClaimsPrincipal
    {
        public IdentityPrincipal(IdentityClaims identity)
            : base(identity)
        {

        }

        public IdentityPrincipal(ClaimsPrincipal claimsPrincipal)
            : base(claimsPrincipal)
        {

        }
        public override bool IsInRole(string role)
        {
            //return base.IsInRole(role);
            return true;
        }
        //public bool IsInGroup(string group)
        //{
        //    return (from claims in FindAll(IdentityConfig.GroupsClaimType) where claims.Value == @group select claims.Value).Count() > 0;
        //}
    }
}
