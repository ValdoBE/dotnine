using System.Text.Json;
using dotnine.Models;

namespace dotnine.Services;

public class GameStateService : IGameStateService
{
    private GameState? GameState { get; set; }
    private const string FileName = "gameState.json"; 

    public GameStateService()
    {
        LoadGame();
    }
    
    public void SaveGame()
    {
        var jsonGameState = JsonSerializer.Serialize(GameState);
        File.WriteAllText(FileName, jsonGameState);
    }

    public void LoadGame()
    {
        if (!File.Exists(FileName)) return;
        var jsonGameState = File.ReadAllText(FileName);
        GameState = JsonSerializer.Deserialize<GameState>(jsonGameState) ?? new GameState();
    }
    
    public GameState? GetGameState() => GameState;
    public void SetGameState(GameState gameState) => GameState = gameState;
}