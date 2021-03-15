using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;
using ComunicationModels;
using ConsolaServiciosWebApp.BussinessClass.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using PruebaTecnicaJavierCalles.Controllers;

namespace TestPruebaTecnica
{
    [TestClass]
    public class HomeControllerTest
    {

        

        [TestMethod]
        public void IndexVista()
        {
            List<ReporteCovid> list = new List<ReporteCovid>();

            IReporteCovidBussinessClass reportCovidService = Substitute.For<IReporteCovidBussinessClass>();
            reportCovidService.RegionSearch().ReturnsForAnyArgs(list);
            HomeController controller = new HomeController(reportCovidService);


            ActionResult accion = controller.Index();

            // Assert
            Assert.IsNotNull(accion);
            Assert.IsNotNull(((ViewResultBase)(accion)).Model);

        }

        [TestMethod]
        public void BuscarRegion()
        {

            List<ReporteCovid> list = new List<ReporteCovid>();
            
            IReporteCovidBussinessClass reportCovidService = Substitute.For<IReporteCovidBussinessClass>();
            reportCovidService.ReporteCovids("USA").ReturnsForAnyArgs(list);
            HomeController controller = new HomeController(reportCovidService);


            ActionResult accion = controller.Index("USA","USA",null);

            // Assert
            Assert.IsNotNull(accion);
            Assert.IsNotNull(((ViewResultBase)(accion)).Model);
        }

        [TestMethod]
        public void ImpresionDocumentos()
        {

            Stream stream = new MemoryStream();

            IReporteCovidBussinessClass reportCovidService = Substitute.For<IReporteCovidBussinessClass>();
            reportCovidService.impresiondedocumentos("XML","USA").ReturnsForAnyArgs(stream);
            HomeController controller = new HomeController(reportCovidService);


            string[] Documentos = { "XML" };
            ActionResult accion = controller.Index("USA", "USA", Documentos );

            // Assert
            Assert.IsNotNull(accion);

        }


    }
}
