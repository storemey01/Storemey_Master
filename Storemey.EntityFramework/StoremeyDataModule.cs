using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Abp.Zero.EntityFramework;
using Storemey.EntityFramework;
using Storemey.Authorization;
using Abp.Authorization;
using Castle.MicroKernel.Registration;
using System;

namespace Storemey
{
    [DependsOn(typeof(AbpZeroEntityFrameworkModule), typeof(StoremeyCoreModule))]
    public class StoremeyDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<StoremeyDbContext>());
Configuration.DefaultNameOrConnectionString = "Default";
            //Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
         
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            //Database.SetInitializer<StoremeyDbContext>(null);
            IocManager.IocContainer.Register(Component
               .For<IPermissionChecker>()
               .ImplementedBy<PermissionChecker>()
               .LifestyleTransient()
               .Named(Guid.NewGuid().ToString())
               .IsDefault());


        }
    }
}
