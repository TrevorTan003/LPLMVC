using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LPLMVC.Models
{
    public class ClaimsStore
    {
        public List<Claim> AllClaims = new List<Claim>()
        {
            new Claim("Create Team", "Create Team"),
            new Claim("Edit Team", "Edit Team"),
            new Claim("Delete Team", "Delete Team")
        };
            
    }
}
