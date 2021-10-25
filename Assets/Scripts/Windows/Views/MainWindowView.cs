using UnityEngine;
using UnityEngine.UI;
using System;

namespace Windows
{
    public class MainWindowView : AbstractWindowView
    {
        public event Action OnFirstChapterStart;
        public event Action OnSecondChapterStart;

        [SerializeField] private Button _firstChapter;
        [SerializeField] private Button _secondChapterChapter;
        
        private void Awake()
        {
            // tmp buttons 
            _firstChapter.onClick.AddListener(() => OnFirstChapterStart?.Invoke());
            _secondChapterChapter.onClick.AddListener(() => OnSecondChapterStart?.Invoke());
        }
    }
}