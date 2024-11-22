using dotnine.Models;

namespace dotnine.Services;

public interface IGameStateService
{
    public void SaveGame();
    public void LoadGame();
    
    public GameState? GetGameState();
    public void SetGameState(GameState state);
}