using ComunicationModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsolaServiciosWebApp.BussinessClass.Interfaces
{
    public interface IReporteCovidBussinessClass
    {
        List<ReporteCovid> RegionSearch();

        List<ReporteCovid> ProvinceSearch(string Region);

        List<ReporteCovid> ReporteCovids(string Region);

        Stream impresiondedocumentos(string Document, String region);

    }
}
