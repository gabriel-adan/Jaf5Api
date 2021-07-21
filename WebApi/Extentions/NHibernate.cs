using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Automapping;
using SharpArch.Domain.DomainModel;
using SharpArch.Domain.PersistenceSupport;
using Microsoft.Extensions.DependencyInjection;
using Domain;
using Infrastructure.Repositories;
using Infrastructure.NHibernateMaps;
using Infrastructure.NHibernateMaps.Conventions;

namespace WebApi.Extentions
{
    public static class NHibernate
    {
        public static IServiceCollection AddNHibernate(this IServiceCollection services, string connectionString)
        {
            try
            {
                var autoPersistenceModel = AutoMap.AssemblyOf<Item>(new AutomappingConfiguration()).UseOverridesFromAssemblyOf<AutomappingConfiguration>();
                autoPersistenceModel.Conventions.AddFromAssemblyOf<LowercaseTableNameConvention>();
                autoPersistenceModel.IgnoreBase<Entity>();
                autoPersistenceModel.IgnoreBase(typeof(EntityWithTypedId<>));
                var sessionFactory = Fluently.Configure()
                    .Database(MySQLConfiguration.Standard.ConnectionString(connectionString).ShowSql())
                    .Mappings(m =>
                    {
                        m.AutoMappings.Add(autoPersistenceModel);
                    })
                    .BuildSessionFactory();

                services.AddSingleton(sessionFactory);
                services.AddScoped(factory => sessionFactory.OpenSession());
                services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
                services.AddScoped(typeof(ITransactionManager), typeof(TransactionManager));
            }
            catch
            {
                throw;
            }
            return services;
        }
    }
}
