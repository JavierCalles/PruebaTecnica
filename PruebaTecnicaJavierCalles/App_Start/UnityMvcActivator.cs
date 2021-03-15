using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity.AspNet.Mvc;


[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(PruebaTecnicaJavierCalles.App_Start.UnityWebActivator), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(PruebaTecnicaJavierCalles.App_Start.UnityWebActivator), "Shutdown")]

namespace PruebaTecnicaJavierCalles.App_Start
{

    public static class UnityWebActivator
    {

        /// <summary>Integrates Unity when the application starts.</summary>
        public static void Start()
        {
            var container = UnityConfig.GetConfiguredContainer();

            FilterProviders.Providers.Remove(FilterProviders.Providers.OfType<FilterAttributeFilterProvider>().First());
            FilterProviders.Providers.Add(new UnityFilterAttributeFilterProvider(container));

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

        }

        /// <summary>Disposes the Unity container when the application is shut down.</summary>
        public static void Shutdown()
        {
            var container = UnityConfig.GetConfiguredContainer();
            container.Dispose();
        }

    }
}