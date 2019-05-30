using Newtonsoft.Json;

namespace ExamWPF
{
  public class Feature
  {
    [JsonProperty("properties")]
    public Property Properties { get; set; }
  }
}
