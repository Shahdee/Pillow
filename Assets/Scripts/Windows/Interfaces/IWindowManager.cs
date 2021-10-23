using System.Collections;
using System.Collections.Generic;
using Windows;
using UnityEngine;

public interface IWindowManager
{
    void OpenWindow(EWindowType windowType);
    void OpenWindowAndCloseOthers(EWindowType windowType);
}
