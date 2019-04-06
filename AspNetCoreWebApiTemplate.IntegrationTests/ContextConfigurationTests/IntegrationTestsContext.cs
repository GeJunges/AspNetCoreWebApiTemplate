using AspNetCoreWebApiTemplate.Infrastructure.ContextConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace AspNetCoreWebApiTemplate.IntegrationTests.ContextConfigurationTests
{
    public class IntegrationTestsContext : IDisposable
    {
        protected readonly AspNetCoreWebApiTemplateContext contextIntegrationTests;

        public IntegrationTestsContext()
        {
            var serviceProvider = new ServiceCollection().AddEntityFrameworkSqlServer().BuildServiceProvider();
            var builder = new DbContextOptionsBuilder<AspNetCoreWebApiTemplateContext>();

            var config = new ConfigurationBuilder()
                        .SetBasePath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Configuration"))
                        .AddJsonFile("appsettings.json").Build();

            var connectionString = config.GetConnectionString("IntegrationTestsDb");

            builder.UseSqlServer(connectionString).UseInternalServiceProvider(serviceProvider);

            contextIntegrationTests = new AspNetCoreWebApiTemplateContext(builder.Options);
            contextIntegrationTests.Database.Migrate();
        }

        public void Dispose()
        {
            contextIntegrationTests.Database.EnsureDeleted();
        }
    }
}
