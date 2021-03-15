using ComunicationModels;
using ConsoladeServicio.Services.Interfaces;
using CsvHelper;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ConsoladeServicio.Services
{
    public class ReportCovidService : IReportCovidService
    {

        public List<ReporteCovid> RegionSearch()
        {
            var client = new RestClient("https://covid-19-statistics.p.rapidapi.com/reports");
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-key", "64d576a7aemsh4f358fb1f653985p162ac0jsn5ca7e65347c8");
            request.AddHeader("x-rapidapi-host", "covid-19-statistics.p.rapidapi.com");
            //  TResponse va = new TResponse();
            IRestResponse restResponse = null;
            restResponse = client.Execute(request);
            var reporte = JsonConvert.DeserializeObject<Datos>(restResponse.Content).Data;


            List<ReporteCovid> v = reporte.OrderBy(l => l.deaths)
                .GroupBy(l => l.region.iso)
                .SelectMany(cl => cl.Select(
                    csLine => new ReporteCovid
                    {
                        date = csLine.date,
                        confirmed = cl.Sum(c => csLine.confirmed),
                        deaths = cl.Sum(c => csLine.deaths),
                        recovered = cl.Sum(c => csLine.recovered),
                        confirmed_diff = cl.Sum(c => csLine.confirmed_diff),
                        deaths_diff = cl.Sum(c => csLine.deaths_diff),
                        recovered_diff = cl.Sum(c => csLine.recovered_diff),
                        last_update = csLine.last_update,
                        active = cl.Sum(c => csLine.active),
                        active_diff = cl.Sum(c => csLine.active_diff),
                        fatality_rate = cl.Sum(c => csLine.fatality_rate),
                        iso = csLine.region.iso,
                        name = csLine.region.name,
                        region = csLine.region

                    }
                    )).ToList<ReporteCovid>();



            List<ReporteCovid> v2 = v.OrderByDescending(l => l.deaths)
                .GroupBy(l => l.iso)
                .Select(cl => new ReporteCovid
                {
                    //                        date = csLine.date,
                    confirmed = cl.Sum(c => c.confirmed),
                    deaths = cl.Sum(c => c.deaths),
                    recovered = cl.Sum(c => c.recovered),
                    confirmed_diff = cl.Sum(c => c.confirmed_diff),
                    deaths_diff = cl.Sum(c => c.deaths_diff),
                    recovered_diff = cl.Sum(c => c.recovered_diff),
                    //                       last_update = csLine.last_update,
                    active = cl.Sum(c => c.active),
                    active_diff = cl.Sum(c => c.active_diff),
                    fatality_rate = cl.Sum(c => c.fatality_rate),
                    iso = cl.First().region.iso,
                    name = cl.First().region.name,
                    region = cl.First().region

                }).Take(10).ToList<ReporteCovid>();

            return v2;
        }

        public List<ReporteCovid> ProvinceSearch(string Region)
        {

            var client = new RestClient("https://covid-19-statistics.p.rapidapi.com/reports?iso=" + Region);
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-key", "64d576a7aemsh4f358fb1f653985p162ac0jsn5ca7e65347c8");
            request.AddHeader("x-rapidapi-host", "covid-19-statistics.p.rapidapi.com");
            //  TResponse va = new TResponse();
            IRestResponse restResponse = null;
            restResponse = client.Execute(request);
            var reporte = JsonConvert.DeserializeObject<Datos>(restResponse.Content).Data;


            List<ReporteCovid> v = reporte.OrderBy(l => l.deaths)
                .GroupBy(l => l.region.iso)
                .SelectMany(cl => cl.Select(
                    csLine => new ReporteCovid
                    {
                        date = csLine.date,
                        confirmed = cl.Sum(c => csLine.confirmed),
                        deaths = cl.Sum(c => csLine.deaths),
                        recovered = cl.Sum(c => csLine.recovered),
                        confirmed_diff = cl.Sum(c => csLine.confirmed_diff),
                        deaths_diff = cl.Sum(c => csLine.deaths_diff),
                        recovered_diff = cl.Sum(c => csLine.recovered_diff),
                        last_update = csLine.last_update,
                        active = cl.Sum(c => csLine.active),
                        active_diff = cl.Sum(c => csLine.active_diff),
                        fatality_rate = cl.Sum(c => csLine.fatality_rate),
                        iso = csLine.region.province,
                        name = csLine.region.province,
                        region = csLine.region

                    }
                    )).ToList<ReporteCovid>();



            List<ReporteCovid> v2 = v.OrderByDescending(l => l.deaths)
                .GroupBy(l => l.iso)
                .Select(cl => new ReporteCovid
                {
                    //                        date = csLine.date,
                    confirmed = cl.Sum(c => c.confirmed),
                    deaths = cl.Sum(c => c.deaths),
                    recovered = cl.Sum(c => c.recovered),
                    confirmed_diff = cl.Sum(c => c.confirmed_diff),
                    deaths_diff = cl.Sum(c => c.deaths_diff),
                    recovered_diff = cl.Sum(c => c.recovered_diff),
                    //                       last_update = csLine.last_update,
                    active = cl.Sum(c => c.active),
                    active_diff = cl.Sum(c => c.active_diff),
                    fatality_rate = cl.Sum(c => c.fatality_rate),
                    iso = cl.First().region.iso,
                    name = cl.First().region.province,
                    region = cl.First().region


                }).Take(10).ToList<ReporteCovid>();

            return v2;
        }

        public List<ReporteCovid> ReporteCovids(string Region)
        {

            List<ReporteCovid> reportCovids = RegionSearch();


            if (Region != "Regions")
            {
                List<ReporteCovid> reportProvince = ProvinceSearch(Region);


                for (int i = 0; i < 10; i++)
                {
                    reportProvince[i].region = reportCovids[i].region;
                }


                return reportProvince;
            }
            else
            {
                return reportCovids;
            }
        }

        public Stream impresiondedocumentos(string Document, String region)
        {

            List<ReporteCovid> reportCovids = ReporteCovids(region);
            List<ReportDocument> reportDocuments = new List<ReportDocument>();
            for(int i= 0; i < 10; i++)
            {
                reportDocuments.Add(new ReportDocument() { iso = reportCovids[i].iso, name = reportCovids[i].name, confirmed = reportCovids[i].confirmed, deaths = reportCovids[i].deaths });
            }


            switch (Document)
            {
                case "JSON":

                    string json = JsonConvert.SerializeObject(reportDocuments);


                    byte[] byteArray = Encoding.UTF8.GetBytes(json);

                    Stream stream = new MemoryStream(byteArray);

                    return stream;
                    break;

                case "XML":



                    XmlDocument xmlDoc = new XmlDocument();
                    XmlSerializer xmlSerializer = new XmlSerializer(reportDocuments.GetType());
                    string v;
                    using (MemoryStream xmlStream = new MemoryStream())
                    {
                        xmlSerializer.Serialize(xmlStream, reportDocuments);
                        xmlStream.Position = 0;
                        xmlDoc.Load(xmlStream);
                        v = xmlDoc.InnerXml;
                    }

                    //stream1.Close();

                    byte[] byteArray2 = Encoding.UTF8.GetBytes(v);

                    Stream stream2 = new MemoryStream(byteArray2);

                    return stream2;

                    break;

                default:



                    byte[] result;

                    using (var memoryStream = new MemoryStream())
                    {
                        using (var streamWriter = new StreamWriter(memoryStream))
                        {
                            using (var csvWriter = new CsvWriter(streamWriter, System.Globalization.CultureInfo.CurrentCulture))
                            {
                                csvWriter.WriteRecords(reportDocuments);
                                streamWriter.Flush();
                                result = memoryStream.ToArray();
                            }
                        }
                    }

                    Stream streamCSV = new MemoryStream(result);

                    return streamCSV;
                    break;
            }
        }

    }
}


class Datos
{
    public List<ReporteCovid> Data { get; set; }
}
