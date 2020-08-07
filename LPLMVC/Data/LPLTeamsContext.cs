using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LPLMVC.Models;

namespace LPLMVC.Data
{
    public class LPLTeamsContext : DbContext
    {
        public LPLTeamsContext (DbContextOptions<LPLTeamsContext> options)
            : base(options)
        {
        }

        public DbSet<LPLMVC.Models.TeamDataModel> TeamDataModels { get; set; }
    }
}
