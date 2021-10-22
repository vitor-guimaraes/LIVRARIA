using Livraria.Domain.Handlers;
using Livraria.Domain.Interfaces.Repositories;
using Livraria.Infra.Data.DataContexts;
using Livraria.Infra.Data.Repositories;
using Livraria.Infra.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Livraria.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region AppSettings

            AppSettings appSettings = new AppSettings();
            Configuration.GetSection("AppSettings").Bind(appSettings);
            services.AddSingleton(appSettings);

            #endregion AppSettings

            #region DataContexts

            services.AddScoped<DataContext>();

            #endregion DataContexts

            #region Repositories

            services.AddTransient<ILivroRepository, LivroRepository>();

            #endregion Repositories

            #region Handlers

            services.AddTransient<LivroHandler, LivroHandler>();

            #endregion Handlers


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Livraria.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Livraria.Api v1"));
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
