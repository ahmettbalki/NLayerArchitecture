using Autofac;
using DataHub.Repository;
using DataHub.Service.Mapping;
using Module = Autofac.Module;
using System.Reflection;
using DataHub.Repository.Repositories;
using NLayerArchitecture.Core.Repositories;
using DataHub.Service.Services;
using NLayerArchitecture.Core.Services;
using DataHub.Repository.UnitOfWorks;
using NLayerArchitecture.Core.UnitOfWorks;
using NLayerArchitecture.Caching;

namespace NLayerArchitecture.API.Modules
{
    public class RepoServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Service<>)).As(typeof(IService<>)).InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

            var apiAssembly = Assembly.GetExecutingAssembly();
            var repoAssembly = Assembly.GetAssembly(typeof(AppDbContext));
            var serviceAssembly = Assembly.GetAssembly(typeof(MapProfile));

            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterType<CompanyServiceWithCaching>().As<ICompanyService>();
        }
    }
}
