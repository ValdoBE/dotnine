using dotnine.Models;
using dotnine.Services;

namespace dotnine;

public interface IGameService
{
    void Start();
    void Update(double deltaTime);
}

public class GameService : IGameService
{
    private readonly IGameStateService _gameStateService;
    private readonly GameState _currentGameState;
    
    private const double BuildingACurrencyPerMillisecond = 0.001;
    private const double BuildingBCurrencyPerMillisecond = 0.003;

    public GameService(IGameStateService gameStateService)
    {
        _gameStateService = gameStateService;

        _currentGameState = _gameStateService.GetGameState() ?? new GameState { Currency = 0 };
    }

    public void Start()
    {
    }

    public void Update(double deltaTime)
    {
        _currentGameState.Currency += BuildingACurrencyPerMillisecond * deltaTime;
        _currentGameState.Currency += BuildingBCurrencyPerMillisecond * deltaTime;
        
        Console.WriteLine($"Currency : {Math.Round(_currentGameState.Currency , 2)}");
        _gameStateService.SetGameState(_currentGameState);
    }
}