using System;
using Game;

namespace Windows
{
    // opens a specific window, depending on game "state"
    // state is an abstract notion 
    
    public class UIController : IUIController, IDisposable
    {
        private readonly IGameController _gameController;
        private readonly IWindowManager _windowManager;

        public UIController(IGameController gameController, IWindowManager windowManager)
        {
            _gameController = gameController;
            _windowManager = windowManager;

            _gameController.OnGameStateChange += OnGameStateChange;
        }

        private void OnGameStateChange(EGameState state)
        {
            switch (state)
            {
                case EGameState.Play:
                    _windowManager.OpenWindowAndCloseOthers(EWindowType.Main);
                    break;
            }
        }

        public void Dispose()
        {
            _gameController.OnGameStateChange -= OnGameStateChange;
        }
    }
}