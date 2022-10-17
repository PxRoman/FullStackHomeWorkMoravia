using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using TranslationManagement.Domain.Ports.Inputs.TranslationJobs;
using TranslationManagement.Domain.Ports.Outputs;
using TranslationManagement.Infrastructure.Adapters.TranslationJobs;
using TranslationManagement.Infrastructure.Database;
using TranslationManagement.Infrastructure.Repositories;

namespace TranslationManagement.Api
{
    public class Startup
    {
        private const string ApiAllowSpecificOrigins = "_frontEndOrigin";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TranslationManagement.Api", Version = "v1" });
            });

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite("Data Source=TranslationAppDatabase.db"));

            services.AddScoped<ITranslationJobRepository, TranslationJobRepository>();

            services.AddScoped<ICreateTranslationJob, CreateTranslationJob>();
            services.AddScoped<IGetTranslationJobsDtoArray, GetTranslationJobsDtoArray>();
            services.AddScoped<IUpdateTranslationJob, UpdateTranslationJob>();

            services.AddCors(options =>
            {
                options.AddPolicy(ApiAllowSpecificOrigins,
                    builder =>
                    {
                        builder
                            .AllowAnyHeader()
                            .WithOrigins("http://localhost:3000")
                            .WithMethods(new[] {"GET", "PUT", "POST", "DELETE"});
                    });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(ApiAllowSpecificOrigins);

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TranslationManagement.Api v1"));

            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
