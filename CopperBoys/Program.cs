using Newtonsoft.Json;
using System.IO;
using System;
using System.Threading.Tasks;

public class Program
{
    public static async Task Main(string[] args)
    {
        string configFileContents = File.ReadAllText("config.json");
        BotConfig config = JsonConvert.DeserializeObject<BotConfig>(configFileContents);

        var bot = new CopperBoysBot(config);
        await bot.StartAsync();

        // Prevent the application from exiting immediately
        await Task.Delay(-1);
    }
}