using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Hour
    {
        public DateTime time { get; set; }
        public WaveHeight waveHeight { get; set; }
        public WavePeriod wavePeriod { get; set; }
    }

    public class Meta
    {
        public double cost { get; set; }
        public int dailyQuota { get; set; }
        public string end { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
        public List<string> @params { get; set; }
        public int requestCount { get; set; }
        public string start { get; set; }
    }

    public class StormglassData
    {
        public List<Hour> hours { get; set; }
        public Meta meta { get; set; }
    }

    public class WaveHeight
    {
        public double dwd { get; set; }
        public double fcoo { get; set; }
        public double fmi { get; set; }
        public double icon { get; set; }
        public double noaa { get; set; }
        public double sg { get; set; }
    }

    public class WavePeriod
    {
        public double fcoo { get; set; }
        public double icon { get; set; }
        public double noaa { get; set; }
        public double sg { get; set; }
    }



}
