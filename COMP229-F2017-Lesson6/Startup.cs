using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

//required for Owin Startup
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Cookies;
[assembly: OwinStartup(typeof(COMP229_F2017_Lesson6.Startup))]

namespace COMP229_F2017_Lesson6
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType=DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath=new PathString("/Login.aspx")

            });
        }
    }
}
