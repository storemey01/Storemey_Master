using System.Configuration;

namespace Storemey
{
    public class StoremeyConsts
    {
        public const string LocalizationSourceName = "Storemey";

        public static string tenantName = string.Empty;

        public static string tenantPassword = string.Empty;

        public static string tenantUserName = string.Empty;

        public static string tenanEmail = string.Empty;

        public static string StoreName = string.Empty;

        public const bool MultiTenancyEnabled = true;

        public static string DomainName = ConfigurationManager.AppSettings["DomainName"].ToString();

        public static bool redirectToLogin = true;

        public static string SequireServerType = "https://";

        public static string HostIPForIIS = ConfigurationManager.AppSettings["HostIPForIIS"].ToString();

    }
}