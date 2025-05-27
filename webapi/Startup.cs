using Microsoft.EntityFrameworkCore;
using webapi.EF;
using webapi.EF.Models;

namespace webapi
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            IConfigurationBuilder builder = GetConfigurationBuilder(environment);
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            WebApi? webApiCache = Configuration.GetSection("WebApi").Get<WebApi>();
            services.AddDbContext<WebApiContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("Master")));
            if (webApiCache != null)
            {
                services.AddSingleton<IAppCache>((IAppCache)webApiCache);
            }
            //services.AddTransient<ITokenService, TokenService>();
            services.AddControllers();
            services.AddCors();
        }

        private IConfigurationBuilder GetConfigurationBuilder(IWebHostEnvironment env)
        {
            return new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddUserSecrets<Startup>()
                .AddEnvironmentVariables();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(t => t.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseAuthorization();
            app.UseHttpsRedirection();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
