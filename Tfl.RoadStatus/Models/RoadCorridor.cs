using System.Text.Json.Serialization;

namespace Tfl.RoadStatus.Models
{
    public class RoadCorridor
    {
        [JsonPropertyName("displayName")]
        public string? DisplayName { get; set; }

        [JsonPropertyName("statusSeverity")]
        public string? StatusSeverity { get; set; }

        [JsonPropertyName("statusSeverityDescription")]
        public string? StatusSeverityDescription { get; set; }
    }
}
