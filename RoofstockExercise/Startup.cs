using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RoofstockExercise.Data.Context;
using RoofstockExercise.Data.Persistence.Implementations;
using RoofstockExercise.Data.Persistence.Interface;
using RoofstockExercise.Data.UnityOfWork;
using RoofstockExercise.Services.Implementation;
using RoofstockExercise.Services.Interface;
using RoofstockExercise.Utils;
using RoofstockExercise.Utils.ActivatorWrapper;

namespace RoofstockExercise
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
            services.AddCors();
            services.AddControllers();
            services.AddRazorPages();

            services.AddDbContext<RoofstockContext>(options => 
                        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //Persistence
            services.AddScoped<IUnityWork, UnityWork>();
            services.AddScoped<IActivatorWrap, ActivatorWrap>();

            //Services
            services.AddScoped<IPropertyService, PropertyService>();

            //Dao
            services.AddScoped<IPropertyDao, PropertyDao>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
