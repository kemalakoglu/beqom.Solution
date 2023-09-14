using System;
using beqom.Domain.Aggregate.RefTypeValue;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace beqom.Domain.Context.Context
{
    public class CoreContext : IdentityDbContext<IdentityUser>
    {
        public CoreContext()
        {
        }

        public CoreContext(DbContextOptions<CoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Option> RefType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(
                    "Data Source=TRISTICTL46W10;Initial Catalog=beqom; Persist Security Info=True;User ID=sa;Password=User123**;MultipleActiveResultSets=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}