using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Windows;
using Audio;
using Chapters;
using Zenject;

namespace Windows
{
    // QA
    // hasValue
    
    // list of available chapters: past + current -> chapter storage 
    // current story 
    // list of saved stories 

    public class MainWindow : AbstractWindow
    {
        public override EWindowType WindowType => EWindowType.Main;
    
        private readonly LazyInject<MainWindowView> _view;
        private readonly IChapterController _chapterController;
        private readonly IAudioController _audioController;

        public MainWindow(LazyInject<MainWindowView> view,
                            IChapterController chapterController,
                            IAudioController audioController)
        {
            _view = view;
            _chapterController = chapterController;
            _audioController = audioController;
        }

        protected override void OnAssignView() => SetView(_view.Value);
        
        protected override void OnAfterShow()
        {
            _view.Value.OnFirstChapterStart += StartFirstChapter;
            _view.Value.OnSecondChapterStart += StartSecondChapter;
        }

        private void StartFirstChapter()
        {
            _chapterController.LaunchChapter(0); // get it from player data 
            
            _audioController.PlaySound(ESoundType.Tap);
        }
        
        private void StartSecondChapter()
        {
            _chapterController.LaunchChapter(1); // get it from player data 
            
            _audioController.PlaySound(ESoundType.Tap);
        }


        protected override void OnBeforeHide()
        {
            _view.Value.OnFirstChapterStart -= StartFirstChapter;
            _view.Value.OnSecondChapterStart -= StartSecondChapter;
        }
    }
}

