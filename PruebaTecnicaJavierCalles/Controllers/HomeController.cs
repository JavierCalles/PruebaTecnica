
using AutoMapper;
using ConsolaServiciosWebApp.BussinessClass.Interfaces;
using PruebaTecnicaJavierCalles.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PruebaTecnicaJavierCalles.Controllers
{
    public class HomeController : Controller
    {

        private readonly IReporteCovidBussinessClass _reporteCovid;

        public HomeController(IReporteCovidBussinessClass reporteCovid)
        {
            _reporteCovid = reporteCovid;
        }


        public ActionResult Index()
        {

            var Report = _reporteCovid.RegionSearch();

            ViewBag.TIPO = "REGION";
            ViewBag.Regions = "Regions";

            return View(Report);

        }


        [HttpPost]
        public ActionResult Index(string Region, string OldRegion, string[] chckDocuments = null)
        {
            if (chckDocuments == null)
            {
                var reportCovid = _reporteCovid.ReporteCovids(Region);
                if (Region != "Regions")
                {
                    ViewBag.TIPO = "PROVINCE";
                }
                else
                {
                    ViewBag.TIPO = "REGION";
                }

                ViewBag.Regions = Region;
                return View(reportCovid);
            }
            else
            {
                Stream streamDocumento = _reporteCovid.impresiondedocumentos(chckDocuments[0], OldRegion);

                switch (chckDocuments[0])
                {
                    case "JSON":

                        return File(streamDocumento, "application/json", "the current top 10.json");
                        break;

                    case "XML":

                        return File(streamDocumento, "application/xml", "the current top 10.xml");

                        break;

                    default:

                        return File(streamDocumento, "text/csv", "the current top 10.csv");
                        break;
                }

            }



        }
    }
}