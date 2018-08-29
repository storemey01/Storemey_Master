using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;
using System;
using System.Web;
using Abp.BackgroundJobs;
using Hangfire;
using Hangfire.Storage;
using Microsoft.Owin.Security;

namespace Storemey.Web.Controllers
{
    //[AbpMvcAuthorize]
    public class HomeController : StoremeyControllerBase
    {

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        public ActionResult Index()
        {
            return View("~/App/Main/views/layout/layout.cshtml"); //Layout of the angular application.
        }
        public ActionResult point()
        {
            return View("~/App/Main/views/layout/layout.cshtml"); //Layout of the angular application.
        }
        public ActionResult SiteMaster()
        {
            if (StoremeyConsts.redirectToLogin)
            {
                if (!AuthenticationManager.User.Identity.IsAuthenticated)
                {
                    Response.Redirect("http://" + StoremeyConsts.DomainName);
                }
                return RedirectToAction("Logout", "Account");
            }

            ////Hangfire.BackgroundJob.Schedule<HomeController>(x => x.testHangfire(), Abp.Timing.Clock.Now.AddSeconds(5));
           
            return View(); //Layout of the angular application.
        }


        //public void testHangfire()
        //{

        //}
        public ActionResult Loading(string redirectURL)
        {
            string parameterdata = PasswordHelper.Aes256CbcEncrypter.Decrypt(redirectURL);
            parameterdata = "redirectURL=" + parameterdata;


            string gotoURL = HttpUtility.ParseQueryString(parameterdata).Get("redirectURL"); 
            string LoadingTimeinsecond = HttpUtility.ParseQueryString(parameterdata).Get("LoadingTimeinsecond");

            ViewBag.LoadingTimeinsecond = (Convert.ToInt32(LoadingTimeinsecond) * 1000);
            ViewBag.redirectURL = gotoURL;

            return View(); //Layout of the angular application.
        }
    }

}