using System;
using System.Text.Json.Serialization;

namespace NumberName.Server.NumberToName.Model
{
    public class NumberNameInput
    {
        [JsonPropertyName("value")]
        public UInt32 Value { get; set; }
        // MaxValue = 2^32 - 4,294,967,295 - four billion two hundred ninety-four million nine hundred sixty-seven thousand two hundred ninety-five
    }
}