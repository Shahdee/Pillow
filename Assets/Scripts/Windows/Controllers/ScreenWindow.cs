using Screens;
using Zenject;
using System;
using Audio;

namespace Windows
{
    
    // assemble an interactable screen 
    
    public class ScreenWindow : AbstractWindow, IScreenWindow
    {
        public event Action OnNextScreen;
        public override EWindowType WindowType => EWindowType.Screen;
        
        private readonly LazyInject<ScreenWindowView> _view;
        private readonly IAudioController _audioController;

        public ScreenWindow(LazyInject<ScreenWindowView> view,
                            IAudioController audioController)
        {
            _view = view;
            _audioController = audioController;
        }

        public void SetScreenData(ScreenData screenData)
        {
            if (screenData == null)
                return;
            
            _view.Value.SetBackground(screenData.ScreenBackground);
        }

        protected override void OnAssignView() => SetView(_view.Value);
        
        protected override void OnAfterShow()
        {
            _view.Value.OnNextClick += NextScreenClick;
            
        }

        private void NextScreenClick()
        {
            _audioController.PlaySound(ESoundType.Tap);
            OnNextScreen?.Invoke();
        }

        protected override void OnBeforeHide()
        {
            _view.Value.OnNextClick -= NextScreenClick;
            
        }
        
    }
}