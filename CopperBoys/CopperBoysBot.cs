using Discord;
using Discord.WebSocket;
using Discord.Commands;
using System;
using System.Threading.Tasks;

public class CopperBoysBot
{
    private BotConfig _config;
    private DiscordSocketClient _client;
    private CommandService _commands;
    private IServiceProvider _services;

    public CopperBoysBot(BotConfig config)
    {
        _config = config;
        _client = new DiscordSocketClient();
        _commands = new CommandServices();
        _services = new ServerCollection();

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

    public async Task RegisterCommandsAsync()
    {
        _client.MessageReceived += HandleCommandAsync(SocketMessage arg);
        await _commands.AddModuleAsync(Assembly.GetEntryAssembly(), _services);
    }

    private async Tast HandeCommandAsync(SocketMEssage arg)
    {
        var message = arg as SocketUserMessage;
        var context = new SocketCommandContext(_client, message);
        if (message.Author.IsBot) return;

        int argPos = 0;
        if (message.HasStringPrefix("!", ref argPos))
        {
            var result = await _commands.ExecuteAsync(context, argPos, _services;
            if (!result.IsSuccess) Console.WriteLine(result.ErrorReason);
        }
    }
}
