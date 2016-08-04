using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Claims;
using System.ComponentModel;
using System.Web.Mvc;

namespace MyProject.Controllers
{
    public class AuthorizeClaim : AuthorizeAttribute
    {
        // Properties
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }

        // Override method
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            // Get a reference to the user
            var user = filterContext.HttpContext.User as ClaimsPrincipal;

            // Matches (below) are case-insensitive

            // Look for claims that match the incoming type
            // The matchingClaims will be a collection of zero or more matching claims
            var matchingClaims = user.Claims
                .Where(c => c.Type.ToLower().Contains(ClaimType.ToLower()));

            // Attempt to locate matching values
            var matchedClaim = false;
            foreach (var claim in matchingClaims)
            {
                if (claim.Value.ToLower() == ClaimValue.ToLower())
                {
                    matchedClaim = true;
                    break;
                }
            }

            if (matchedClaim)
            {
                // Yes, authorized
                base.OnAuthorization(filterContext);
            }
            else
            {
                // No, not authorized
                base.HandleUnauthorizedRequest(filterContext);
            }
        }

    }

}
