using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            services.AddCors();

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

                ConventionModelMapper conventionalMappings = CreateConventionalMappings();
                var mapping = conventionalMappings.CompileMappingFor(GetType().Assembly.GetExportedTypes().Where(t => t.Namespace.EndsWith("Entities")));
                cfg.AddDeserializedMapping(mapping, "dacs");


                return cfg.BuildSessionFactory();
            });

            services.AddScoped<ISession>((provider) =>
            {
                var factory = provider.GetService<ISessionFactory>();
                return factory.OpenSession();
            });
        }

    private ConventionModelMapper CreateConventionalMappings()
    {
        var mapper = new ConventionModelMapper();

        var baseEntityType = typeof(BaseEntity);
        mapper.IsEntity((t, declared) => baseEntityType.IsAssignableFrom(t) && baseEntityType != t && !t.IsInterface);
        mapper.IsRootEntity((t, declared) => baseEntityType.Equals(t.BaseType));

        mapper.BeforeMapManyToOne += (insp, prop, map) => map.Column(prop.LocalMember.GetPropertyOrFieldType().Name + "Id");
        mapper.BeforeMapManyToOne += (insp, prop, map) => map.Cascade(Cascade.Persist);
        mapper.BeforeMapBag += (insp, prop, map) => map.Key(km => km.Column(prop.GetContainerEntity(insp).Name + "Id"));
        mapper.BeforeMapBag += (insp, prop, map) => map.Cascade(Cascade.All);
        mapper.BeforeMapClass += (modelInspector, type, map) =>
        {
            map.Table($"{type.Name}s");
            map.Id(m =>
            {
                m.Column($"{type.Name.ToUpper()}ID");
            });
        };

        mapper.Class<BaseEntity>(map =>
        {
            map.Id(x => x.Id, m => m.Generator(Generators.Increment));
        });

        mapper.Class<Producto>(map => map.Component<Position>(x => x.Position, cm =>
        {
            cm.Property(p => p.Latitude, mc => mc.Column("Latitude"));
            cm.Property(p => p.Longitude, mc => mc.Column("Longitude"));
        }));

        return mapper;
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
                var session = app.ApplicationServices.GetService<ISession>();
                if (session == null) throw new ArgumentNullException(nameof(session));

                try
                {
                    session.BeginTransaction();
                    await next.Invoke();
                    session.Transaction.Commit();
                }
                catch (Exception e)
                {
                    session.Transaction.Rollback();
                }
            });
                                
            app.UseMvc();
        }
    }
}
