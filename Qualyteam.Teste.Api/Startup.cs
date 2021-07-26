using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Qualyteam.Teste.Data.Context;
using Qualyteam.Teste.Data.Repository;
using Qualyteam.Teste.Data.Repository.Interface;
using Qualyteam.Teste.Service.Implementations;
using Qualyteam.Teste.Service.Interface;

namespace Qualyteam.Teste.Api
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Qualyteam.Teste.Api", Version = "v1" });
            });

            services.AddScoped<DbContext, TesteQualyteamDBContext>();
            services.AddScoped<ISalesKpiRepository, SalesKpiRepository>();
            services.AddScoped<ISalesKpiService, SalesKpiService>();
            
            string mySqlConnectionStr = Configuration.GetConnectionString("DefaultConnection");  
            services.AddDbContextPool<TesteQualyteamDBContext>(options => options.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr)));           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Qualyteam.Teste.Api v1"));
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
