using System;
using Windows;
using Chapters;

namespace Screens
{
    // shows current targets 
    // reports done when all targets are completed  

    public class ScreenController : IScreenController, IDisposable
    {
        public event Action<int, int> OnScreenLaunch;
        public event Action OnScreenComplete;
        
        private readonly IChapterDataProvider _chapterDataProvider;
        private readonly IScreenWindow _screenWindow;

        public ScreenController(IChapterDataProvider chapterDataProvider,
                                IScreenWindow screenWindow)
        {
            _chapterDataProvider = chapterDataProvider;
            _screenWindow = screenWindow;

            _screenWindow.OnNextScreen += ScreenChange;
        }
        
        public bool LaunchScreen(int chapterId, int screenId)
        {
            var screenData = _chapterDataProvider.GetScreenData(chapterId, screenId);
            if (screenData == null)
                return false;
            
            _screenWindow.SetScreenData(screenData);

            OnScreenLaunch?.Invoke(chapterId, screenId);

            return true;
        }

        private void ScreenChange()
        {
            OnScreenComplete?.Invoke();
        }

        public void Dispose()
        {
            _screenWindow.OnNextScreen -= ScreenChange;
        }
    }
}