using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LPLMVC.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LPLMVC.Models;

namespace LPLMVC.Data
{
    public class LPLMVCContext : IdentityDbContext<LPLMVCUser>
    {
        public LPLMVCContext(DbContextOptions<LPLMVCContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
