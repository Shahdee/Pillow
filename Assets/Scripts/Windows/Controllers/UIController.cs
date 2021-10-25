using System;
using Chapters;
using Game;
using Screens;

namespace Windows
{
    // opens a specific window, depending on game "state"
    // state is an abstract notion 
    
    public class UIController : IUIController, IDisposable
    {
        private readonly IGameController _gameController;
        private readonly IWindowManager _windowManager;
        private readonly IChapterController _chapterController;
        private readonly IScreenController _screenController;

        public UIController(IGameController gameController,
                            IWindowManager windowManager,
                            IChapterController chapterController,
                            IScreenController screenController)
        {
            _gameController = gameController;
            _windowManager = windowManager;
            _chapterController = chapterController;
            _screenController = screenController;

            _gameController.OnGameStateChange += OnGameStateChange;
            _chapterController.OnChapterComplete += ChapterComplete;
            _screenController.OnScreenLaunch += ScreenLaunch;
        }

        public void OpenWindow(EWindowType windowType) => _windowManager.OpenWindow(windowType);

        private void OnGameStateChange(EGameState state)
        {
            switch (state)
            {
                case EGameState.Play:
                    _windowManager.OpenWindowAndCloseOthers(EWindowType.Main);
                    break;
            }
        }
        
        private void ScreenLaunch(int chapterId, int screenId)
        {
            OpenWindow(EWindowType.Screen);
        }

        private void ChapterComplete(int chapterId)
        {
            _windowManager.OpenWindowAndCloseOthers(EWindowType.Main);
        }
        

        public void Dispose()
        {
            _gameController.OnGameStateChange -= OnGameStateChange;
            
            _chapterController.OnChapterLaunch -= ChapterComplete;
        }
    }
}