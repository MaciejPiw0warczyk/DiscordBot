using Newtonsoft.Json;

namespace DiscordBot
{
    public struct ConfJSON
    {

        [JsonProperty("token")]
        public string Token { get; private set; }

        [JsonProperty("prefix")]
        public string Prefix { get;private set; }
    }
}
