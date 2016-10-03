using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace For.Authentication
{
    public class ForPrincipal : ClaimsPrincipal
    {
        public ForPrincipal(ForClaims identity)
            : base(identity)
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
