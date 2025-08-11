using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.WebApi;
using EmailBuilder.Services;
using EmailBuilder.Services.Interfaces;

namespace EmailBuilder
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // Autofac setup
            var builder = new ContainerBuilder();

            // Register your Web API controllers
            builder.RegisterApiControllers(typeof(WebApiApplication).Assembly);

            // Register your services (replace with your actual implementations)
            builder.RegisterType<MailTrapService>().As<IMailTrapService>().InstancePerRequest();
            builder.RegisterType<MailService>().As<IMailService>().InstancePerRequest();

            var container = builder.Build();

            // Set Autofac as the Web API dependency resolver
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            if (HttpContext.Current.Request.Url.AbsolutePath == "/")
            {
                HttpContext.Current.Response.Redirect("~/api/Eb/Index");
            }
        }
    }
}
