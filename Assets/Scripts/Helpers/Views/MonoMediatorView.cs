using UnityEngine;
using System;

namespace Helpers
{
    public class MonoMediatorView : MonoBehaviour
    {
        public event Action<float> OnUpdate;
        
        private void Update()
        {
            OnUpdate?.Invoke(Time.deltaTime);
        }
    }
}