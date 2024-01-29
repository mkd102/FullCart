using EFDAL;
using InterfaceDAL;
using InterfaceService;
using Models;
using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Binder
{
    public class Startup
    {
        public IConfiguration configRoot
        {
            get;
        }
        public Startup(IConfiguration configuration)
        {
            configRoot = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IUserService,UserService>();
           services.AddSingleton(typeof(IDAL<User>), typeof(EFDAL<User>));
            services.AddCors();
            services.AddRazorPages();
            services.AddSwaggerGen();
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
           
        }
        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            app.UseCors(builder => builder
                   .AllowAnyHeader()
                   .AllowAnyMethod()
                   .AllowAnyOrigin()
                );
            if (!app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();

        }
    }

}
