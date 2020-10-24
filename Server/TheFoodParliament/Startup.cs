using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TheFoodParliament.Domain.Services;
using TheFoodParliament.Domain.Wrappers;
using TheFoodParliament.Infrastructure.Context;
using TheFoodParliament.Infrastructure.Repositories;

namespace TheFoodParliament
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
            services.AddScoped<IDateTimeWrapper, DateTimeWrapper>();
            services.AddScoped<IPlacesApiWrapper, PlacesApiWrapper>();
            services.AddScoped<IRestaurantService, RestaurantService>();
            services.AddScoped<IVoteService, VoteService>();
            services.AddScoped<IElectionService, ElectionService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IElectionRepository, ElectionRepository>();
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

            services.AddDbContext<ParliamentContext>(p => p.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Commented to allow HTTP
            //app.UseHttpsRedirection();

            // Usando somente em dev
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
