using ComunicationModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoladeServicio.Services.Interfaces
{
    public interface IReportCovidService
    {

        List<ReporteCovid> RegionSearch();

        List<ReporteCovid> ProvinceSearch(string Region);

        List<ReporteCovid> ReporteCovids(string Region);

        Stream impresiondedocumentos(string Document, String region);

    }
}
