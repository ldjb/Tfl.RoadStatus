using System.Text.Json.Serialization;

namespace Tfl.RoadStatus.Models
{
    /// <summary>
    /// A RoadCorridor in the Unified API.
    /// </summary>
    public class RoadCorridor
    {
        /// <summary>
        /// The road corridor's display name.
        /// </summary>
        [JsonPropertyName("displayName")]
        public string? DisplayName { get; set; }

        /// <summary>
        /// The road corridor's status severity.
        /// </summary>
        [JsonPropertyName("statusSeverity")]
        public string? StatusSeverity { get; set; }

        /// <summary>
        /// A description of the road corridor's status severity.
        /// </summary>
        [JsonPropertyName("statusSeverityDescription")]
        public string? StatusSeverityDescription { get; set; }
    }
}
