using AspNetCoreWebApiTemplate.Domain.Interfaces;
using AspNetCoreWebApiTemplate.Infrastructure.ContextConfiguration;
using AspNetCoreWebApiTemplate.Infrastructure.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;

namespace AspNetCoreWebApiTemplate
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionSting = Configuration.GetConnectionString("DevDb");
            services.AddDbContext<AspNetCoreWebApiTemplateContext>(opt => opt.UseSqlServer(connectionSting), ServiceLifetime.Transient);

            services.AddAutoMapper();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient(typeof(IReadOnlyRepository<>), typeof(ReadOnlyRepository<>));
            services.AddTransient(typeof(IWritingRepository<>), typeof(WritingRepository<>));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            RegisterSwaggerGenerator(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddLog4Net();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            ConfigureSwaggerMiddleware(app);
            app.UseHttpsRedirection();
            app.UseMvc();
        }

        private void RegisterSwaggerGenerator(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "my API", Version = "v1" });
            });
        }

        private static void ConfigureSwaggerMiddleware(IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "my API V1");
            });
        }
    }
}
