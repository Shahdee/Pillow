using System;

namespace Game
{
    public interface IGameController
    {
        event Action<EGameState> OnGameStateChange;
        EGameState GameState { get; }
    }
}