using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using System.Configuration;
using HelpForSick.Repository;

namespace HelpForSick.WebUI.Frontend
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            string connectionString = ConfigurationManager.ConnectionStrings["HelpForSickEntities"].ConnectionString;
            container.RegisterType<IArticleRepository, EFArticleRepository>(new InjectionConstructor(connectionString));

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}