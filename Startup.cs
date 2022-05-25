using Locacao.Domain.Interfaces;
using Locacao.Domain.Servicos;
using Locacao.Infra.Database;
using Locacao.Infra.Repositorios;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locacao
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

            services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
            services.AddScoped<IVeiculoRepositorio, VeiculoRepositorio>();
            services.AddScoped<IAgenciaRepositorio, AgenciaRepositorio>();
            services.AddScoped<IContratoRepositorio, ContratoRepositorio>();
            services.AddScoped<ICondutorRepositorio, CondutorRepositorio>();
            services.AddScoped<IReboqueRepositorio, ReboqueRepositorio>();
            services.AddScoped<ITerceiroRepositorio, TerceiroRepositorio>();
            services.AddScoped<IFotoRepositorio, FotoRepositorio>();
            services.AddScoped<IComunicadoSinistroRepositorio, ComunicadoSinistroRepositorio>();



            services.AddScoped<ICriptografarServico, CriptografarServico>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ComunicadoSinistro", Version = "v1" });
            });

            services.AddDbContext<EntityContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefautConection")));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ComunicadoSinistro v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
