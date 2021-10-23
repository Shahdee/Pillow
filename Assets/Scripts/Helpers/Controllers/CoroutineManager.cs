using System.Collections;
using UnityEngine;

namespace Helpers
{
    public class CoroutineManager : ICoroutineManager
    {
        private CoroutineManagerView _view;
        
        public CoroutineManager()
        {
            _view = new GameObject().AddComponent<CoroutineManagerView>();
        }

        public void StartCoroutine(IEnumerator coroutine) => _view.StartCoroutine(coroutine);

        public void StopCoroutine(IEnumerator coroutine) => _view.StopCoroutine(coroutine);

        public void StopAllCoroutines() => _view.StopAllCoroutines();
    }
}