using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Slijterij_Sjonnie_Loper.Core;

namespace Slijterij_Sjonnie_Loper.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Slijterij_Sjonnie_Loper.Core.Whiskey> Whiskey { get; set; }
    }
}
