using Discord;
using Discord.WebSocket;
using System;
using System.Threading.Tasks;

public class CopperBoysBot
{
    private DiscordSocketClient _client;
    private BotConfig _config;

    public CopperBoysBot(BotConfig config)
    {
        _config = config;
        _client = new DiscordSocketClient();

        _client.Log += LogAsync;
    }

    public async Task StartAsync()
    {
        await _client.LoginAsync(TokenType.Bot, _config.Token);
        await _client.StartAsync();

        // Hook up your event handlers and bot functionality here
    }

    private Task LogAsync(LogMessage log)
    {
        Console.WriteLine(log);
        return Task.CompletedTask;
    }
}