using UnityEngine;
using System;

namespace Windows
{
    //QA
    // How did I handle carnvas order in other projects ? 
    // - maybe there was no issue cause I was always closing windows 
    
    public abstract class AbstractWindow : IWindow
    {
        public event Action<IWindow> OnClose;
        public abstract EWindowType WindowType { get; }
        
        private IWindowView _view;
        private Transform _parent;
        private int _windowOrder = -1;

        public void SetOrder(int order)
        {
            if (_view != null)
                _view.SetOrder(order);
            else
                _windowOrder = order;
        }
        
        public void SetParent(Transform transform)
        {
            if (_view != null)
                _view.ViewTransform.SetParent(transform);
            else
                _parent = transform;
        }
        
        public void Open()
        {
            OnAssignView();
            OnBeforeShow();
            _view.Open();
            OnAfterShow();
        }


        public void Close()
        {
            OnBeforeHide();
            _view.Close();
            OnAfterHide();
            
            OnClose?.Invoke(this);
        }
        
        protected void SetView(IWindowView view)
        {
            _view = view;
            
            if (_parent != null)
                _view.ViewTransform.SetParent(_parent);
            
            if (_windowOrder > -1)
                _view.SetOrder(_windowOrder);
        }
        
        protected abstract void OnAssignView();
        protected virtual void OnBeforeShow(){}
        protected virtual void OnAfterShow(){}
        protected virtual void OnBeforeHide(){}
        protected virtual void OnAfterHide(){}
    }
}