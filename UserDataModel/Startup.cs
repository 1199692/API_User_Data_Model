using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RoleDataModel.RoleData;
using UnitDataModel.UnitData;
using URoleDataModel.URoleData;
using UserDataModel.Models;
using UserDataModel.UserData;

namespace UserDataModel
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

            services.AddDbContextPool<UserContext>(options => options.UseSqlServer
        (Configuration.GetConnectionString("UserContextConnectionString")));


            //services.AddScoped<IUserData, SqlUserData>();
            services.AddScoped<IUserData, UserDataService>();
            services.AddScoped<IUnitData, UnitDataService>();
            services.AddScoped<IRoleData, RoleDataService>();
            services.AddScoped<IURoleData, URoleDataService>();
            services.AddDbContext<UserContext>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
