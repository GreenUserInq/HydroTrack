using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydroTrack.Models
{
    public class TelemetryData
    {
        public int ID { get; set; }
        public int WaterLevel1 { get; set; }
        public int WaterLevel2 { get; set; }
        public int DegreeOfClogging1 { get; set; }
        public int DegreeOfClogging2 { get; set; }
        public int CloggingHeader1 { get; set; }
        public int CloggingHeader2 { get; set; }
        public int StructuralDeformations { get; set; }
        public string AlarmState { get; set; } = string.Empty;
        public string Errors { get; set; } = string.Empty;
    }
}
