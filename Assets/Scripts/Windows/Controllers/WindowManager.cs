using System;
using System.Collections.Generic;
using System.Linq;
using Initialization;
using UnityEngine;

namespace Windows
{
    // Opens a window 
    
    public class WindowManager : IInitializable, IWindowManager, IDisposable
    {
        // list, stack, queue, array, enumerable, hash
    
        public event Action OnDone;

        private readonly List<IWindow> _allWindows;
        private readonly Stack<IWindow> _stackedWindows;
        private Transform _windowParent;
    
        public WindowManager(List<IWindow> allWindows)
        {
            _allWindows = allWindows;
            _stackedWindows = new Stack<IWindow>();
        }

        public void Init()
        {
            _windowParent = new GameObject().transform;
            _windowParent.name = "WindowParent";

            foreach (var window in _allWindows)
                window.OnClose += OnWindowClose;

            OnDone?.Invoke();
        }

        public void OpenWindowAndCloseOthers(EWindowType windowType)
        {
            while (_stackedWindows.Count > 0)
                _stackedWindows.Peek()?.Close();
            
            OpenWindow(windowType);
        }

        public void OpenWindow(EWindowType windowType)
        {
            var windowToOpen = _allWindows.FirstOrDefault(w => w.WindowType == windowType);
            if (windowToOpen == null)
                return;
            
            _stackedWindows.Push(windowToOpen);

            windowToOpen.SetParent(_windowParent); // why it happens every time we open it? 
            windowToOpen.Open();
        }

        private void OnWindowClose(IWindow closingWindow)
        {
            var stackWindow = _stackedWindows.Peek();
            if (stackWindow == closingWindow)
                _stackedWindows.Pop();
        }

        public void Dispose()
        {
            foreach (var window in _allWindows)
                window.OnClose -= OnWindowClose;
        }
    
    }
}