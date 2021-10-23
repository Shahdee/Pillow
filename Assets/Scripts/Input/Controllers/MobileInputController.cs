using UnityEngine;
using System;
using UnityEngine.EventSystems;

namespace Input
{
    public class MobileInputController : AbstractInputController
    {
        private DateTime _quickTouchCurrTime;
        private Vector2 _touchCurrPosition;
        private Touch _currentTouch;

        public override float GetHorizontalAxis()
        {
            if (_enabled)
                throw new NotImplementedException();
                
            return 0;
        }

        public override float GetVerticalAxis()
        {
            if (_enabled)
                throw new NotImplementedException();
            
            return 0;
        }

        protected override void UpdateInput()
        {
            Debug.Log("& ");
            
            if (_touchInProgress && EventSystem.current.IsPointerOverGameObject())
            {
                _touchInProgress = false;
                return;
            }

            if (UnityEngine.Input.touchCount > 0)
            {
                _currentTouch = UnityEngine.Input.GetTouch(0);

                switch (_currentTouch.phase)
                {
                    case TouchPhase.Began:
                        _quickTouchCurrTime = DateTime.Now;
                        _touchInProgress = true;
                        break;

                    case TouchPhase.Moved:
                   
                        break;

                    case TouchPhase.Ended:
                        if (_touchInProgress && (DateTime.Now - _quickTouchCurrTime).Seconds < QuickTouchMaxTimeDelta)
                        {
                            _touchInProgress = false;
                            QuickTouch(_currentTouch.position);
                        }
                        break;
                }
            }
        }
    }
}