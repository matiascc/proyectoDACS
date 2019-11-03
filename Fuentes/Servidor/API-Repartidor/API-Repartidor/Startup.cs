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
using System.Reflection;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using System.IO;
using API_Repartidor.DAO;
using API_Repartidor.Exceptions;



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

            //Crea el SessionFactory para la conexión con la BD
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

                var sessionFactory = cfg.BuildSessionFactory();

//Carga script de la base de datos
#if DEBUG
                using (var session = sessionFactory.OpenSession())
                using (var transaction = session.BeginTransaction())
                using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("API_Repartidor.Scripts.import.sql"))
                using (StreamReader reader = new StreamReader(stream))
                {
                    var lines = reader.ReadToEnd().Split(System.Environment.NewLine);
                    foreach (var line in lines)
                    {
                        var sqlStatement = line.Trim();
                        if (sqlStatement != string.Empty)
                        {
                            session.CreateSQLQuery(sqlStatement).ExecuteUpdate();
                        }
                    }

                    transaction.Commit();
                }
#endif

                return sessionFactory;
            });

            services.AddScoped<ISession>((provider) =>
            {
                var factory = provider.GetService<ISessionFactory>();
                return factory.OpenSession();
            });

            this.ConfigureAutomapper();

            //Agrega Servicios vinculados a las entidades
            services.AddScoped<PedidosService>();
            services.AddScoped<RepartosService>();
            services.AddScoped<ProductosService>();
            services.AddScoped<ClientesService>();
            services.AddScoped<ProductosDAO>();
            services.AddScoped<PedidosDAO>();
            services.AddScoped<ItemPedidosDAO>();
            services.AddScoped<RepartosDAO>();

            //Agrega el servicio del Swagger
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


            //Middleware - Manejo de Excepciones
            app.Use(async (context, next) =>
            {
                try
                {
                    await next.Invoke();
                }
                catch (UnauthorizedException e)
                {
                    context.Response.StatusCode = 401;
                    Console.WriteLine(e.Message);
                }
                catch (IdNotFoundException e)
                {
                    context.Response.StatusCode = 400;
                    Console.WriteLine(e.Message);
                }
                catch (Exception) //Para cualquier excepcion desconocida
                {
                    context.Response.StatusCode = 500;
                }
            });

            //Middleware - Inicio y fin de transaccion con BD
            //Middleware para las transacciones de la BD
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
                    throw e;
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

        //Crea los mapeos necesarios
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


                //Mapeos entre Entites y DTOs
                cfg.CreateMap<Entities.Pedido, DTOs.PedidoDTO>()
                .ForMember(dest => dest.id, origin => origin.MapFrom(c => c.Id))
                .ForMember(dest => dest.fechaCreacion, origin => origin.MapFrom(c => c.fechaCreacion))
                .ForMember(dest => dest.fechaFinalizacion, origin => origin.MapFrom(c => c.fechaFinalizacion))
                .ForMember(dest => dest.fechaLimite, origin => origin.MapFrom(c => c.fechaLimite))
                .ForMember(dest => dest.entregado, origin => origin.MapFrom(c => c.entregado))
                .ForMember(dest => dest.precioTotal, origin => origin.MapFrom(c => c.precioTotal))
                .ForMember(dest => dest.idCliente, origin => origin.MapFrom(c => c.idCliente))
                .ReverseMap();

                cfg.CreateMap<Entities.ItemPedido, DTOs.ItemPedidoDTO>()
                .ForMember(dest => dest.id, origin => origin.MapFrom(c => c.Id))
                .ForMember(dest => dest.cantidad, origin => origin.MapFrom(c => c.cantidad))
                .ForMember(dest => dest.cantidadRechazada, origin => origin.MapFrom(c => c.cantidadRechazada))
                .ForMember(dest => dest.precio, origin => origin.MapFrom(c => c.precio))
                .ForMember(dest => dest.idProducto, origin => origin.MapFrom(c => c.idProducto))
                .ReverseMap();

                cfg.CreateMap<Entities.Reparto, DTOs.RepartoDTO>()
                .ForMember(dest => dest.id, origin => origin.MapFrom(c => c.Id))
                .ForMember(dest => dest.fecha, origin => origin.MapFrom(c => c.fecha))
                .ForMember(dest => dest.finalizado, origin => origin.MapFrom(c => c.finalizado))
                .ForMember(dest => dest.pedidos, origin => origin.MapFrom(c => c.pedidos))
                .ReverseMap();
            });
        }

    }
}
