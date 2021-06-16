using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using NotificationApp.Api;
using NotificationApp.Application;
using NotificationApp.Data;
using NotificationApp.Domain;
using NotificationApp.Domain.Models;

namespace NotificationApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            var dbOptions = new DbUnitOfWorkOptions();
            this.Configuration.GetSection("db").Bind(dbOptions);

            services.AddSingleton(dbOptions);
            services.AddScoped<IUnitOfWorkRegistry, ThreadLocalUnitOfWorkRegistry>();

            services.AddApi();
            services.AddData();
            services.AddDomain();
            services.AddModels();
            services.AddApplication();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Tests", Version = "v1" });
            });

            services.AddMvcCore();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Tests v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
