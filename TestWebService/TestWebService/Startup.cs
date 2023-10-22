using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using TestWebService.Data;
using TestWebService.Services.Implementation;
using TestWebService.Services.Interface;
using TestWebService.Helpers;

namespace TestWebService
{
    //startup configuration of the service
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        //This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers();
            services.AddControllers().AddNewtonsoftJson();          //JSON support (when frontend submits data/objects to the service)
            services.AddHttpClient();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            //configure DBContext
            services.AddDbContext<TestWebServiceContext>(options => options.UseSqlServer(Configuration.GetConnectionString("TESTDB")));
            var appSettingSection = Configuration.GetSection("AppSettings");
            services.Configure<DaemonConfig>(appSettingSection);
            //configure dependency injection (DI) for application services       
            services.AddScoped<ICollegeService, CollegeService>();
        }

        //This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}