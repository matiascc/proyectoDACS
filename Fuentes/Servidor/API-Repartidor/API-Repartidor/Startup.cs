using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Repartidor.DTOs;
using API_Repartidor.DTOs.ExternalApiDTOs;
using API_Repartidor.Services;
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
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using API_Repartidor.Mappings;

namespace API_Repartidor
{
    public class Startup
    {
        private readonly Automapper autoMapper = new Automapper();
        private const string TOKEN_HEADER_ITEM = "token-id";
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

            services.AddSingleton((provider) =>
            {
                var firebaseApp = FirebaseApp.Create(new AppOptions()
                {
                    Credential = GoogleCredential.FromFile("privatekey.json"),
                });
                
                return firebaseApp;
            });

            //Configuracion de mapeos entre DTOs y Entities
            this.autoMapper.ConfigureAutomapper();

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
                catch (Exception e) //Para cualquier excepcion desconocida
                {
                    context.Response.StatusCode = 500;
                    Console.WriteLine(e.Message);
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


            //Middleware autenticacion Firebase
            app.Use(async (context, next) =>
            {
                    try
                    {
                        var firebaseAuth = new Firebase.Auth.FirebaseAuthProvider(new Firebase.Auth.FirebaseConfig("AIzaSyAhKx_ibS2ENE2Kw01E8mD-KKaXjiQGybU"));
                        var link = await firebaseAuth.SignInWithEmailAndPasswordAsync("miltonalbornoz07@gmail.com", "14108744");

                        context.Request.Headers.Add(TOKEN_HEADER_ITEM, link.FirebaseToken);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

                    await next.Invoke();
            });

            //Middleware autenticacion Firebase

            app.Use(async (context, next) =>
            {
                var firebaseApp = app.ApplicationServices.GetService<FirebaseApp>();

                var firebaseAuth = FirebaseAdmin.Auth.FirebaseAuth.GetAuth(firebaseApp);

                if (context.Request.Headers.ContainsKey(TOKEN_HEADER_ITEM))
                {
                    try
                    {
                        var idToken = context.Request.Headers[TOKEN_HEADER_ITEM];
                        var token = await firebaseAuth.VerifyIdTokenAsync(idToken.First());

                        var user = await firebaseAuth.GetUserAsync(token.Uid);
                        context.Items.Add("CurrentUser", user);

                        await next.Invoke();
                    }
                    catch (Exception)
                    {
                        throw new UnauthorizedException();
                    }
            }
                else
            {
                throw new UnauthorizedException();
            }
        });


            app.UseCors("MyPolicy");
            
            app.UseMvc();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyAPI");
            });
        }
    }
}
