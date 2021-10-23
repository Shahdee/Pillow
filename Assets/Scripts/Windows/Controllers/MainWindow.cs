using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Windows;
using Zenject;

namespace Windows
{
    // QA
    // hasValue

    public class MainWindow : AbstractWindow
    {
        public override EWindowType WindowType => EWindowType.Main;
    
        private readonly LazyInject<MainWindowView> _view;
        // private readonly MainWindowView _view;

        // public MainWindow(MainWindowView view)
        public MainWindow(LazyInject<MainWindowView> view)
        {
            _view = view;
        }

        protected override void OnAssignView() => SetView(_view.Value);
    }
}

// list of available chapters: past + current -> chapter storage 
// current story 
// list of saved stories 