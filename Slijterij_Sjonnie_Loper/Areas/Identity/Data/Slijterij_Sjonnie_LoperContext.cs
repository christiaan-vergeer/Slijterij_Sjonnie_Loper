using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Slijterij_Sjonnie_Loper.Data;

namespace Slijterij_Sjonnie_Loper.Data
{
    public class Slijterij_Sjonnie_LoperContext : IdentityDbContext<Staff>
    {
        public Slijterij_Sjonnie_LoperContext(DbContextOptions<Slijterij_Sjonnie_LoperContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
