using System;
using Abp.Castle.Logging.Log4Net;
using Abp.Web;
using Castle.Facilities.Logging;
using Abp.WebApi.Validation;
using System.Threading;
using System.Web;
using System.Data.Entity;
using Storemey.EntityFramework;
using System.Configuration;

namespace Storemey.Web
{
    public class MvcApplication : AbpWebApplication<StoremeyWebModule>
    {
        protected override void Application_Start(object sender, EventArgs e)
        {
            AbpBootstrapper.IocManager.IocContainer.AddFacility<LoggingFacility>(
                f => f.UseAbpLog4Net().WithConfig(Server.MapPath("log4net.config"))
            );

            base.Application_Start(sender, e);


        }




        protected override void Application_BeginRequest(Object source, EventArgs e)
        {
            try
            {

                Database.SetInitializer<StoremeyDbContext>(null);
                var app = (HttpApplication)source;
                var hostURL = app.Context.Request.Url.Host;


                StoremeyConsts.tenantName = string.IsNullOrEmpty(hostURL.ToLower().Replace(StoremeyConsts.DomainName, ""))
                    ? string.Empty
                    : hostURL.ToLower().Replace(StoremeyConsts.DomainName, "");


                if (StoremeyConsts.tenantName != "" && hostURL.Replace(StoremeyConsts.tenantName, "").Replace(StoremeyConsts.DomainName, "") == "")
                {
                    StoremeyConsts.redirectToLogin = true;
                }
                else
                {
                    StoremeyConsts.redirectToLogin = false;
                }
                StoremeyConsts.tenantName = StoremeyConsts.tenantName.Replace(".", "");
                
                if (!string.IsNullOrEmpty(StoremeyConsts.tenantName) && StoremeyConsts.tenantName == "StoremeyMaster")
                {
                    StoremeyConsts.StoreName = string.Empty;
                }
                else
                {
                    StoremeyConsts.StoreName = StoremeyConsts.tenantName;
                }
            }
            catch (Exception)
            {

            }
        }

    }
}
