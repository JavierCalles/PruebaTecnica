using ComunicationModels;
using ConsoladeServicio.Services;
using ConsoladeServicio.Services.Interfaces;
using ConsolaServiciosWebApp.BussinessClass.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;

namespace ConsolaServiciosWebApp.BussinessClass
{
    public class ReporteCovidBussinessClass : IReporteCovidBussinessClass
    {

        private readonly IReportCovidService _solicitudService;

        public ReporteCovidBussinessClass(IReportCovidService solicitudService)
        {
            _solicitudService = solicitudService;
        }

        public List<ReporteCovid> RegionSearch()
        {
          return  _solicitudService.RegionSearch();
        }

        public List<ReporteCovid> ProvinceSearch(string Region)
        {
            return _solicitudService.ProvinceSearch(Region);
        }

        public List<ReporteCovid> ReporteCovids(string Region)
        {
            return _solicitudService.ReporteCovids(Region);
        }

        public Stream impresiondedocumentos(string Document, String region)
        {
            return _solicitudService.impresiondedocumentos(Document, region);
        }



    }
}
