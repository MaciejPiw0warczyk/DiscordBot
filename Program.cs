using System;
using DSharpPlus;

namespace DiscordBot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("HelloWorld I'm a BOT");
            var bot = new Bot();
            bot.RunAsync().GetAwaiter().GetResult();
        }
    }
}