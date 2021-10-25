using Screens;
using System;

namespace Windows
{
    public interface IScreenWindow
    {
        event Action OnNextScreen;
        
        void SetScreenData(ScreenData screenData);
    }
}