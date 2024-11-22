// See https://aka.ms/new-console-template for more information

using dotnine;
using dotnine.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services.AddSingleton<IGameStateService, GameStateService>();
builder.Services.AddSingleton<IGameService, GameService>();
using IHost host = builder.Build();

ConfigureGame(host.Services);

await host.RunAsync();


static void ConfigureGame(IServiceProvider services)
{
    var gameService = services.GetService<IGameService>();
    var gameStateService = services.GetService<IGameStateService>();
    
    if (gameService is null)
        return;

    if (gameStateService is null)
        return;
    
    gameService.Start();

    DateTime? lastTime = null;
    double totalTime = 0;

    while (true)
    {
        var currentTime = DateTime.Now;
        lastTime ??= currentTime;

        var deltaTime = currentTime - lastTime;
    
        gameService.Update(deltaTime.Value.TotalMilliseconds);

        lastTime = currentTime;
        totalTime += deltaTime.Value.TotalMilliseconds;
        
        gameStateService.SaveGame();
    
        Thread.Sleep(1000/60);
    }
}


