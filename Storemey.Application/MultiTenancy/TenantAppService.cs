using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.IdentityFramework;
using Abp.MultiTenancy;
using Abp.Runtime.Security;
using Storemey.Authorization;
using Storemey.Authorization.Roles;
using Storemey.Authorization.Users;
using Storemey.Editions;
using Storemey.MultiTenancy.Dto;
using Microsoft.AspNet.Identity;
using System.Configuration;
using Microsoft.Web.Administration;
using System.IO;
using System;
using System.Threading;

namespace Storemey.MultiTenancy
{
    //[AbpAuthorize(PermissionNames.Pages_Tenants)]
    public class TenantAppService : AsyncCrudAppService<Tenant, TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>, ITenantAppService
    {
        private readonly TenantManager _tenantManager;
        private readonly EditionManager _editionManager;
        private readonly RoleManager _roleManager;
        private readonly UserManager _userManager;
        private readonly IAbpZeroDbMigrator _abpZeroDbMigrator;

        public TenantAppService(
            IRepository<Tenant, int> repository,

            TenantManager tenantManager,
            EditionManager editionManager,
            UserManager userManager,

            RoleManager roleManager,
            IAbpZeroDbMigrator abpZeroDbMigrator
        ) : base(repository)
        {
            _tenantManager = tenantManager;
            _editionManager = editionManager;
            _roleManager = roleManager;
            _abpZeroDbMigrator = abpZeroDbMigrator;
            _userManager = userManager;
        }

        public override async Task<TenantDto> Create(CreateTenantDto input)
        {
            CheckCreatePermission();

            //Create tenant
            var tenant = ObjectMapper.Map<Tenant>(input);


            if (string.IsNullOrEmpty(input.ConnectionString))
                input.ConnectionString = ConfigurationManager.AppSettings["dbConnectionString"].Replace("[dbName]", input.TenancyName);

            tenant.ConnectionString = input.ConnectionString.IsNullOrEmpty()
                ? null
                : SimpleStringCipher.Instance.Encrypt(input.ConnectionString);

            var defaultEdition = await _editionManager.FindByNameAsync(EditionManager.DefaultEditionName);
            if (defaultEdition != null)
            {
                tenant.EditionId = defaultEdition.Id;
            }

            await _tenantManager.CreateAsync(tenant);
            await CurrentUnitOfWork.SaveChangesAsync(); //To get new tenant's id.


            string oldvalue = StoremeyConsts.tenantName;
            StoremeyConsts.tenantName = string.Empty;

            //Create tenant database
            _abpZeroDbMigrator.CreateOrMigrateForTenant(tenant);

            //Thread.Sleep(1000 * 60 * 1);
            StoremeyConsts.tenantName = oldvalue;


            //We are working entities of new tenant, so changing tenant filter
            //using (CurrentUnitOfWork.SetTenantId(tenant.Id))
            //{
            //    //Create static roles for new tenant
            //    CheckErrors(await _roleManager.CreateStaticRoles(tenant.Id));

            //    await CurrentUnitOfWork.SaveChangesAsync(); //To get static role ids

            //    //grant all permissions to admin role
            //    var adminRole = _roleManager.Roles.Single(r => r.Name == StaticRoleNames.Tenants.Admin);
            //    await _roleManager.GrantAllPermissionsAsync(adminRole);

            //    //Create admin user for the tenant
            //    var adminUser = User.CreateTenantAdminUser(tenant.Id, input.AdminEmailAddress, User.DefaultPassword);
            //    CheckErrors(await _userManager.CreateAsync(adminUser));
            //    await CurrentUnitOfWork.SaveChangesAsync(); //To get admin user's id

            //    //Assign admin user to role!
            //    CheckErrors(await _userManager.AddToRoleAsync(adminUser.Id, adminRole.Name));
            //    await CurrentUnitOfWork.SaveChangesAsync();
            //}
            HostNewTenanetOnIIS(tenant.TenancyName);

            return MapToEntityDto(tenant);
        }

        public async Task<TenantDto> CreateTeant(CreateTenantDto input)
        {
            CheckCreatePermission();



            //Create tenant
            var tenant = ObjectMapper.Map<Tenant>(input);

            

            if (string.IsNullOrEmpty(input.ConnectionString))
                input.ConnectionString = ConfigurationManager.AppSettings["dbConnectionString"].Replace("[dbName]", input.TenancyName);

            tenant.ConnectionString = input.ConnectionString.IsNullOrEmpty()
                ? null
                : SimpleStringCipher.Instance.Encrypt(input.ConnectionString);

            var defaultEdition = await _editionManager.FindByNameAsync(EditionManager.DefaultEditionName);
            if (defaultEdition != null)
            {
                tenant.EditionId = defaultEdition.Id;
            }

            await _tenantManager.CreateAsync(tenant);
            await CurrentUnitOfWork.SaveChangesAsync(); //To get new tenant's id.


            string oldvalue = StoremeyConsts.tenantName;
            StoremeyConsts.tenantName = string.Empty;

            //Create tenant database
            _abpZeroDbMigrator.CreateOrMigrateForTenant(tenant);

            //Thread.Sleep(1000 * 60 * 1);
            StoremeyConsts.tenantName = oldvalue;

            HostNewTenanetOnIIS(tenant.TenancyName);

            return MapToEntityDto(tenant);
        }



        public async Task<bool> TenancyExistsAsync(string TenancyName)
        {
            var tenant = await _tenantManager.FindByTenancyNameAsync(TenancyName);

            if (tenant != null)
                return true;
            else
                return false;

        }

        public void HostNewTenanetOnIIS(string TenancyName)
        {
            string appPoolName = "Storemey";
            ServerManager serverManager = new ServerManager();

            // Create new AppPool or use existing
            ApplicationPool appPool = serverManager.ApplicationPools.FirstOrDefault(x => x.Name == appPoolName);

            if (appPool == null)
                appPool = serverManager.ApplicationPools.Add(appPoolName);

            // Umbraco is .NET 4.0
            appPool.ManagedRuntimeVersion = "v4.0";

            // Add site and configure
            // string physicalPath = "D:\\Storemey Projects\\Projects\\Storemey\\Storemey.Web"; System.IO.Path.Combine(siteLocation, UmbracoGenerator.Code.Constants.UmbracoRuntimeRelativePath);
            //serverManager.Sites.Add(appPoolName, physicalPath, 80);

            string newsubSite = "*:80:" + TenancyName + "." + StoremeyConsts.DomainName;
            string newsubSite2 = "*:443:" + TenancyName + "." + StoremeyConsts.DomainName;
            serverManager.Sites["Storemey"].ApplicationDefaults.ApplicationPoolName = appPoolName;
            //serverManager.Sites["Storemey"].Bindings.Clear();

            //serverManager.Sites[StartArguments.Name].Bindings.Add("*:80:" + hostName, "http");
            serverManager.Sites["Storemey"].Bindings.Add(newsubSite, "http");
            serverManager.Sites["Storemey"].Bindings.Add(newsubSite2, "https");


            serverManager.Sites["Storemey"].ServerAutoStart = true;

            ModifyHostsFile(TenancyName);
            // Commit
            serverManager.CommitChanges();

        }

        public static bool ModifyHostsFile(string newsubSite)
        {
            try
            {
                using (StreamWriter w = File.AppendText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), @"drivers\etc\hosts")))
                {
                    w.WriteLine("\n" + StoremeyConsts.HostIPForIIS + " " + newsubSite + "." + StoremeyConsts.DomainName);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        protected override void MapToEntity(TenantDto updateInput, Tenant entity)
        {
            //Manually mapped since TenantDto contains non-editable properties too.
            entity.Name = updateInput.Name;
            entity.TenancyName = updateInput.TenancyName;
            entity.IsActive = updateInput.IsActive;
        }

        public override async Task Delete(EntityDto<int> input)
        {
            CheckDeletePermission();

            var tenant = await _tenantManager.GetByIdAsync(input.Id);
            await _tenantManager.DeleteAsync(tenant);
        }

        private void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}