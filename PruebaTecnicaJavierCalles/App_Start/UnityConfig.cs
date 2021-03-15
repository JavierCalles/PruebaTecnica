using ConsoladeServicio.Services;
using ConsoladeServicio.Services.Interfaces;
using ConsolaServiciosWebApp.BussinessClass;
using ConsolaServiciosWebApp.BussinessClass.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity;

namespace PruebaTecnicaJavierCalles.App_Start
{
    public class UnityConfig
    {

        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }

        public static TResult GetInstance<TResult>() where TResult : class
        {
            TResult result = default(TResult);

            if (container.IsValueCreated)
            {
                result = container.Value.Resolve<TResult>();
            }

            return result;
        }
        #endregion

        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IReportCovidService, ReportCovidService>();
            container.RegisterType<IReporteCovidBussinessClass, ReporteCovidBussinessClass>();

        }

    }
}