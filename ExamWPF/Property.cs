using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamWPF
{
  public class Property
  {
    [JsonProperty("mag")]
    public double Mag { get; set; }

    [JsonProperty("place")]
    public string Place { get; set; }

    [JsonProperty("time")]
    [JsonConverter(typeof(timesecond))]
    public DateTime Time { get; set; }

    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("DepthMin")]
    public double? DepthMin { get; set; }
  }
}
