using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SilverCarnival.Api.Middleware;

namespace SilverCarnival.Api
{
    // ReSharper disable once UnusedMember.Global // This is used by ASP.net Managed code
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddCors(options =>
                {
                    options.AddPolicy("AllowDevelopmentOrigins",
                        builder =>
                        {
                            builder.WithOrigins("http://localhost:4300")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                        });
                })
                .AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app = env.IsDevelopment() ? app.UseDeveloperExceptionPage().UseCors("AllowDevelopmentOrigins") : app.UseHsts().UseHttpsRedirection();
            app.UseMiddleware(typeof(ErrorHandling))
                .UseHttpsRedirection()
                .UseRouting()
                .UseAuthorization()
                .UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}