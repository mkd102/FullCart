using EFDAL;
using Models;
using InterfaceDAL;
using TokenWebApi.TokenCreation;

namespace TokenWebApi
{
    public class Startup
    {
        private ConfigurationManager configuration;

        public Startup(ConfigurationManager configuration)
        {
            this.configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(typeof(IDAL<User>), typeof(EFDAL<User>));
            services.AddSingleton(typeof(IDAL<UserRole>), typeof(EFDAL<UserRole>));
            services.AddSingleton(typeof(IDAL<Role>), typeof(EFDAL<Role>));

            services.AddSingleton<ITokenCreation, CreateToken>();
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
