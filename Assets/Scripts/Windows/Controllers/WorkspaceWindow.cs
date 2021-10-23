using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Windows;
using UnityEngine;
using Zenject;

namespace Windows
{
    public class WorkspaceWindow : AbstractWindow
    {
        public override EWindowType WindowType => EWindowType.Workspace;

        // private readonly WorkspaceWindowView _view;
        private readonly LazyInject<WorkspaceWindowView> _view;
    
        // public WorkspaceWindow(WorkspaceWindowView view)
        public WorkspaceWindow(LazyInject<WorkspaceWindowView> view)
        {
            _view = view;
        }

        protected override void OnAssignView() => SetView(_view.Value);
    }
}

// tools 
// colors 
// paper 