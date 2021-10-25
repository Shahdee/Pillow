using System;

namespace Screens
{
    public interface IScreenController
    {
        event Action<int, int> OnScreenLaunch;
        
        event Action OnScreenComplete;
        
        bool LaunchScreen(int chapterId, int screenId);
    }
}