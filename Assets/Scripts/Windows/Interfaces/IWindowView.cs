using UnityEngine.UI;
using UnityEngine;

namespace Windows
{
    public interface IWindowView
    {
        Transform ViewTransform { get; }

        void Open();

        void Close();
    }
}