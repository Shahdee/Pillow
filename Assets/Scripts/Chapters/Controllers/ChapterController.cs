using System;
using Screens;


namespace Chapters
{
    // launches sequence of screens for current chapter 
    // reports when chapter is completed 
    
    public class ChapterController : IChapterController, IDisposable
    {
        public event Action<int> OnChapterLaunch;
        public event Action<int> OnChapterComplete;
        
        private readonly IChapterDataProvider _chapterDataProvider;
        private readonly IScreenController _screenController;
        
        private int _currentChapter;
        private int _currentScreen;
        
        public ChapterController(IChapterDataProvider chapterDataProvider,
                                IScreenController screenController)
        {
            _chapterDataProvider = chapterDataProvider;
            _screenController = screenController;

            _screenController.OnScreenComplete += ScreenComplete;
        }
        
        public bool LaunchChapter(int chapterId)
        {
            if (!_chapterDataProvider.HasScreen(chapterId))
                return false;
            
            OnChapterLaunch?.Invoke(chapterId);

            _currentChapter = chapterId;
            _currentScreen = 0;
            
            var launched = LaunchScreen(_currentChapter, _currentScreen);
            return launched;
        }
        
        private bool LaunchScreen(int chapterId, int screenId) => _screenController.LaunchScreen(chapterId, screenId);

        private void ScreenComplete()
        {
            _currentScreen++;
            var launched = LaunchScreen(_currentChapter, _currentScreen);

            if (!launched)
                OnChapterComplete?.Invoke(_currentChapter);
        }

        public void Dispose()
        {
            _screenController.OnScreenComplete -= ScreenComplete;
        }
    }
}