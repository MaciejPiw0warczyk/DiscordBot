using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Interactivity;
using Newtonsoft.Json;

namespace DiscordBot
{
    internal class Bot
    {
        public DiscordClient Client { get; private set; }
        public CommandsNextExtension Commands { get; private set; }

        public async Task RunAsync()
        {
            var json = "";
            using(var fs = File.OpenRead("Conf/config.json"))
            using (var sr = new StreamReader(fs, new UTF8Encoding(false)))
                json = await sr.ReadToEndAsync().ConfigureAwait(false);

            var confJson = JsonConvert.DeserializeObject<ConfJSON>(json);

            var conf = new DiscordConfiguration()
            {
                Token = confJson.Token,
                TokenType = TokenType.Bot,
                AutoReconnect = true,
                MinimumLogLevel = Microsoft.Extensions.Logging.LogLevel.Debug
            };
            var comandsConf = new CommandsNextConfiguration()
            {
                StringPrefixes = new string[] { confJson.Prefix },
                EnableMentionPrefix = true,
                EnableDms = false
            };

            Client = new DiscordClient(conf);
            Commands = Client.UseCommandsNext(comandsConf);



            Client.Ready += Client_Ready;


            await Client.ConnectAsync();


            await Task.Delay(-1);
        }

        private Task Client_Ready(DiscordClient sender, DSharpPlus.EventArgs.ReadyEventArgs e)
        {
            return Task.CompletedTask;
        }


    }
}
