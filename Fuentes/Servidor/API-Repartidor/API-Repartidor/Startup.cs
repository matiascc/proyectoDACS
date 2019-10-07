using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Repartidor.DTOs;
using API_Repartidor.DTOs.APIProductsDTOs;
using API_Repartidor.Services;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace API_Repartidor
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
            this.ConfigureAutomapper();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSingleton<PedidosService>();
            services.AddSingleton<RepartosService>();
            services.AddSingleton<ProductosService>();


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API_Repartidor", Version = "v-1.0" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json" , "MyAPI");
            });
        }

        public void ConfigureAutomapper()
        {
            
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ProductDTO, ProductoDTO>()
                .ForMember(dest => dest.id, origin => origin.MapFrom(c => c.id))
                .ForMember(dest => dest.nombre, origin => origin.MapFrom(c => c.name))
                .ForMember(dest => dest.codigoQR, origin => origin.MapFrom(c => c.code))
                .ForMember(dest => dest.descripcion, origin => origin.MapFrom(c => c.description))
                .ForMember(dest => dest.fabricante, origin => origin.MapFrom(c => c.brand));

                
                cfg.CreateMap<DTOs.APIProductsDTOs.StockDTO, DTOs.StockDTO>()
                .ForMember(dest => dest.id, origin => origin.MapFrom(c => c.stock_id))
                .ForMember(dest => dest.idZona, origin => origin.MapFrom(c => c.zone_id))
                .ForMember(dest => dest.cantidad, origin => origin.MapFrom(c => c.quantity));
                
            });
        }

    }
}
