using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SaveTime.DataAccess;
using SaveTimeCore.AbstractModels;
using SaveTimeCore.Domain.AutoMapperConfigurations;
using SaveTimeCore.Services;

namespace SaveTimeCore.WebAPI
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
            services.AddControllers();

            services.AddDbContext<YClientsContext>(option =>
            {
                option.UseSqlServer(Configuration.GetConnectionString("YClient"));
            });
            services.AddScoped<DbContext, YClientsContext>();
            services.AddScoped(typeof(IRepository<,>), typeof(DbRepository<,>));
            services.AddScoped(typeof(IService<,,>), typeof(Service<,,>));
            services.AddTransient<IMapper>(config => AutoMapperConfiguration.Config());
            services.AddTransient<IEncrypter, Hashing>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
