using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Windows;
using UnityEngine;
using Zenject;

namespace Windows
{
    // storytelling sequence: images, videos, drawing quests
    
    public class StoryWindow : AbstractWindow
    {
        public override EWindowType WindowType => EWindowType.Story;

        // private readonly StoryWindowView _view;
        private readonly LazyInject<StoryWindowView> _view;
    
        // public StoryWindow(StoryWindowView view)
        public StoryWindow(LazyInject<StoryWindowView> view)
        {
            _view = view;
        }

        protected override void OnAssignView() => SetView(_view.Value);

          
    }
}