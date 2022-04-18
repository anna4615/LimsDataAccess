using System.Text.Json.Serialization;

namespace LimsDataAccess.GraphQL.TestClasses
{
    public class TestInput
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("sampleId")]
        public int? SampleId { get; set; }

        [JsonPropertyName("elisaId")]
        public int? ElisaId { get; set; }

        [JsonPropertyName("sampleName")]
        public string SampleName { get; set; }

        [JsonPropertyName("platePosition")]
        public int? ElisaPlatePosition { get; set; }

        [JsonPropertyName("measuredValue")]
        public float? MeasuredValue { get; set; }

        [JsonPropertyName("concentration")]
        public float? Concentration { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

    }
}
