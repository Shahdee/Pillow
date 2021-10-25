using System;
using UnityEngine;
using UnityEngine.UI;

namespace Windows
{
    public class ScreenWindowView : AbstractWindowView
    {
        public event Action OnNextClick;
        
        [SerializeField] private Image _background;
        [SerializeField] private Button _buttonNext;

        private void Awake()
        {
            _buttonNext.onClick.AddListener(() => OnNextClick?.Invoke());
        }

        public void SetBackground(Sprite backSprite)
        {
            _background.sprite = backSprite;
        }
    }
}