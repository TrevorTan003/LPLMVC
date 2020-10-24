using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LPLMVC.Models
{
    public class UserClaimsModel
    {
        public UserClaimsModel()
        {
            Claims = new List<UsersClaims>();
        }

        public string UserId { get; set; }
        public List<UsersClaims> Claims { get; set; }
    }
}