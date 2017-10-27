using System.Collections.Generic;

namespace Sharpenter.IAM.Repository.EntityFramework
{
    public class DbInitializer
    {
        public static void Seed(IdentityContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            
            context.Set<Core.User>().AddRange(new List<Core.User>
            {
                new Core.User("user-1"),
                new Core.User("user-2"),
                new Core.User("user-3")
            });
            context.SaveChanges();
        }
    }
}