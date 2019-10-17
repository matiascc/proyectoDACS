using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Repartidor.DTOs;
using API_Repartidor.DTOs.ExternalApiDTOs;
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
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Connection;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;
using API_Repartidor.DataComponents;
using API_Repartidor.Entities;
using System.Reflection;
using NHibernate.Tool.hbm2ddl;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc.Cors.Internal;

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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            }));
            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new CorsAuthorizationFilterFactory("MyPolicy"));
            });


            services.AddSingleton<ISessionFactory>((provider) =>
            {
                var cfg = new NHibernate.Cfg.Configuration();

                string connectionString = Microsoft.Extensions.Configuration.ConfigurationExtensions.GetConnectionString(this.Configuration, "DefaultConnection");

                cfg.DataBaseIntegration(config =>
                {
                    config.ConnectionProvider<DriverConnectionProvider>();
                    config.KeywordsAutoImport = Hbm2DDLKeyWords.AutoQuote;
                    config.Timeout = 60;
                    config.LogFormattedSql = true;
                    config.LogSqlInConsole = false;
                    config.AutoCommentSql = false;
                    config.Dialect<PostgreSQL83Dialect>();
                    config.Driver<NpgsqlDriver>();
                    config.ConnectionString = connectionString;
                    config.SchemaAction = SchemaAutoAction.Recreate;
                });
                var mapper = new ModelMapper();
                mapper.AddMappings(Assembly.GetExecutingAssembly().GetExportedTypes());
                var domainMapping = mapper.CompileMappingForAllExplicitlyAddedEntities();
                cfg.AddMapping(domainMapping);

                return cfg.BuildSessionFactory();
            });

            services.AddScoped<ISession>((provider) =>
            {
                var factory = provider.GetService<ISessionFactory>();
                return factory.OpenSession();
            });

            this.ConfigureAutomapper();

            services.AddSingleton<PedidosService>();
            services.AddSingleton<RepartosService>();
            services.AddSingleton<ProductosService>();
            services.AddSingleton<ClientesService>();


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

            app.Use(async (context, next) =>
            {
                var serviceScope = app.ApplicationServices.CreateScope();
                var session = serviceScope.ServiceProvider.GetService<ISession>();

                try
                {
                    session.Transaction.Begin();
                    await next.Invoke();
                    session.Transaction.Commit();
                }
                catch (Exception e)
                {
                    session.Transaction.Rollback();
                }
                finally
                {
                    session.Close();
                }
            });

            app.UseCors("MyPolicy");
            
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
                .ForMember(dest => dest.descripcion, origin => origin.MapFrom(c => c.description));

                cfg.CreateMap<ProductDTO, ProductoCompletoDTO>()
                .ForMember(dest => dest.id, origin => origin.MapFrom(c => c.id))
                .ForMember(dest => dest.codigoQR, origin => origin.MapFrom(c => c.code))
                .ForMember(dest => dest.nombre, origin => origin.MapFrom(c => c.name))
                .ForMember(dest => dest.descripcion, origin => origin.MapFrom(c => c.description))
                .ForMember(dest => dest.fabricante, origin => origin.MapFrom(c => c.brand))
                .ForMember(dest => dest.imagen, origin => origin.MapFrom(c => c.image));


                cfg.CreateMap<DTOs.ExternalApiDTOs.StockDTO, DTOs.StockDTO>()
                .ForMember(dest => dest.id, origin => origin.MapFrom(c => c.stock_id))
                .ForMember(dest => dest.idZona, origin => origin.MapFrom(c => c.zone_id))
                .ForMember(dest => dest.cantidad, origin => origin.MapFrom(c => c.quantity));
                
                cfg.CreateMap<DTOs.ExternalApiDTOs.ClientDTO, DTOs.ClienteDTO>()
                .ForMember(dest => dest.id, origin => origin.MapFrom(c => c.id))
                .ForMember(dest => dest.nombre, origin => origin.MapFrom(c => c.name))
                .ForMember(dest => dest.direccion, origin => origin.MapFrom(c => c.address))
                .ForMember(dest => dest.email, origin => origin.MapFrom(c => c.email))
                .ForMember(dest => dest.telefonoFijo, origin => origin.MapFrom(c => c.fixed_phone))
                .ForMember(dest => dest.telefonoCelular, origin => origin.MapFrom(c => c.cell_phone))
                .ForMember(dest => dest.cuit, origin => origin.MapFrom(c => c.legal_id));
            });
        }

    }
}
