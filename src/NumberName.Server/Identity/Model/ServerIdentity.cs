using System.Text.Json.Serialization;

namespace NumberName.Server.Identity.Model
{
    public class ServerIdentity
    {
        [JsonPropertyName("server_name")]
        public string ServerName { get; set; }
    }
}