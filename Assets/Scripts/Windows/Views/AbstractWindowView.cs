using UnityEngine;

namespace Windows
{
    public class AbstractWindowView : MonoBehaviour, IWindowView
    {
        public Transform ViewTransform => transform;

        [SerializeField] private Canvas _canvas;

        public void Open() => gameObject.SetActive(true);
        public void Close() => gameObject.SetActive(false);
        public void SetOrder(int order) => _canvas.sortingOrder = order;
    }
}