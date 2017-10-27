using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sharpenter.IAM.Repository.EntityFramework.User
{
    public class UserTypeConfiguration : IEntityTypeConfiguration<Core.User>
    {
        public void Configure(EntityTypeBuilder<Core.User> builder)
        {
            builder.Property(u => u.Id).UseSqlServerIdentityColumn();
            builder.Property(u => u.Username).IsRequired();
        }
    }
}