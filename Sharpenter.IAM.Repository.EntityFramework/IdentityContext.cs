using Microsoft.EntityFrameworkCore;
using Sharpenter.IAM.Repository.EntityFramework.User;

namespace Sharpenter.IAM.Repository.EntityFramework
{
    public class IdentityContext : DbContext
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserTypeConfiguration());
        }
    }
}