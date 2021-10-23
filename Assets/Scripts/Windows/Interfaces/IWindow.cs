using UnityEngine;
using System;

namespace Windows
{
    public interface IWindow
    {
        event Action<IWindow> OnClose;
        EWindowType WindowType { get; }
        void Open();
        void SetParent(Transform transform);
        void Close();
    }
}