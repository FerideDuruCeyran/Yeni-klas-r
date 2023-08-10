using System.Text.Json.Serialization;

namespace Eticaret.Model
{
    public class Data
    {
        [JsonPropertyName("TRY")]
        public TRY TRY { get; set; }
    }

    public class Meta
    {
        [JsonPropertyName("last_updated_at")]
        public DateTime LastUpdatedAt { get; set; }
    }

    public class Kur
    {
        [JsonPropertyName("meta")]
        public Meta Meta { get; set; }

        [JsonPropertyName("data")]
        public Data Data { get; set; }
    }

    public class TRY
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("value")]
        public double Value { get; set; }
    }


}
