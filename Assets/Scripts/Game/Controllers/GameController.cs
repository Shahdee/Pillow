using System;
using Initialization;
using UnityEngine;

// launches the game 
// notifies subscribers about current game state  

namespace Game
{
    public class GameController : IGameController, IDisposable
    {
        public EGameState GameState => _gameState;

        public event Action<EGameState> OnGameStateChange;

        private EGameState _gameState;
        
        private readonly IInitializeMediator _initializeMediator;

        public GameController(IInitializeMediator initializeMediator)
        {
            _initializeMediator = initializeMediator;
            _initializeMediator.OnDone += InitDone;
        }

        private void InitDone()
        {
            Debug.Log("init done...");
            
            SetGameState(EGameState.Play);
        }

        private void SetGameState(EGameState state)
        {
            if (_gameState == state)
                return;
            
            _gameState = state;
            OnGameStateChange?.Invoke(_gameState);
        }

        public void Dispose()
        {
            _initializeMediator.OnDone -= InitDone;
        }
    }
}