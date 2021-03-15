using System;

namespace ComunicationModels
{
    public class ReporteCovid
    {
        public string iso { get; set; }

        public string name { get; set; }

        public string date { get; set; }
        public Int32 confirmed { get; set; }
        public Int32 deaths { get; set; }
        public Int32 recovered { get; set; }
        public Int32 confirmed_diff { get; set; }
        public Int32 deaths_diff { get; set; }
        public Int32 recovered_diff { get; set; }
        public string last_update { get; set; }
        public Int32 active { get; set; }
        public Int32 active_diff { get; set; }
        public double fatality_rate { get; set; }
        public region region { get; set; }
    }
}
