using System;
using System.Text.Json.Serialization;

namespace NumberName.Server.NumberToName.Model
{
    public class NumberNameOutput
    {
        [JsonPropertyName("value")]
        public UInt32 Value { get; set; }

        [JsonPropertyName("value_in_words")]
        public string ValueInWords { get; set; }
    }
}