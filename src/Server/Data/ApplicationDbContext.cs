using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<EmailAddress> EmailAddresses { get; set; }
        public DbSet<EmailContent> EmailContents { get; set; }
        public DbSet<EmailHeader> EmailHeaders { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<EmailAddress>()
                .HasIndex(m => m.Address)
                .IsUnique();

            builder.Entity<Account>()
                .HasIndex(m => m.Email)
                .IsUnique();
        }
    }
}
