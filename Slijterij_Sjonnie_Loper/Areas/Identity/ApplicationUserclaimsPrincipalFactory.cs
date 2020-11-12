using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Slijterij_Sjonnie_Loper.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Slijterij_Sjonnie_Loper.Areas.Identity
{
    public class ApplicationUserclaimsPrincipalFactory : UserClaimsPrincipalFactory<Staff, IdentityRole>
    {
        public ApplicationUserclaimsPrincipalFactory(UserManager<Staff> userManager,
                                                        RoleManager<IdentityRole> roleManager,
                                                        IOptions<IdentityOptions> options): base (userManager,roleManager, options)
        {

        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(Staff user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim("fullname", user.fullname));
            identity.AddClaim(new Claim("Role", user.Role));

            return identity; 
        }
    }
}
