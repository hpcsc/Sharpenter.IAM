using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sharpenter.IAM.Repository.EntityFramework;
using Xunit;

namespace Sharpenter.IAM.UI.Web.Tests
{
    public class DatabaseFixture : IDisposable
    {
        public DatabaseFixture()
        {
            Environment.SetEnvironmentVariable("ConnectionStrings:Sharpenter.IAM", Config.TestConnectionString);

            var optionsBuilder = new DbContextOptionsBuilder<IdentityContext>().UseSqlServer(Config.TestConnectionString);
            using (var context = new IdentityContext(optionsBuilder.Options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }
        }

        public void Dispose()
        {
        }
    }
    
    [CollectionDefinition("DatabaseCollection")]
    public class DatabaseCollection : ICollectionFixture<DatabaseFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
}